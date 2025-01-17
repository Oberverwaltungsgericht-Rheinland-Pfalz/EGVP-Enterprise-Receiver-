﻿using OvgRlp.EgvpEpReceiver.Infrastructure;
using OvgRlp.EgvpEpReceiver.Infrastructure.Contracts;
using OvgRlp.EgvpEpReceiver.Infrastructure.EgvpEnterpriseSoap;
using OvgRlp.EgvpEpReceiver.Infrastructure.Models;
using OvgRlp.Libs.Logging;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace OvgRlp.EgvpEpReceiver.Services
{
  public class ProtocolService
  {
    private IMessageSource _messageSource;

    public ProtocolService(IMessageSource messageSource)
    {
      _messageSource = messageSource;
    }

    // Logging Metadaten aufbereiten
    private void ExtendedLogMetadata(EGVPMessageProps msgProps, ref LogMetadata logMetadata, string messageID = null, EgvpPostbox egvpPostbox = null, string messageSizeKB = null, string messageSizeAttachmentsKB = null, string departmentCode = null)
    {
      if (null == logMetadata)
        logMetadata = new LogMetadata();
      logMetadata.AppVersion = OvgRlp.Core.Common.AssemblyHelper.AssemblyVersion(System.Reflection.Assembly.GetEntryAssembly());

      if (null != messageID)
        logMetadata.MessageId = messageID;
      if (null != messageSizeKB)
        logMetadata.MessageSizeKB = messageSizeKB;
      if (null != messageSizeAttachmentsKB)
        logMetadata.MessageSizeAttachmentsKB = messageSizeAttachmentsKB;
      if (null != departmentCode)
        logMetadata.DepartmentCode = departmentCode;
      if (null != egvpPostbox)
      {
        logMetadata.Recipient = egvpPostbox.Id;
        logMetadata.RecipientName = egvpPostbox.Name;
      }

      ExtendedLogMetadataFromState(messageID, egvpPostbox, ref logMetadata);

      if (null != msgProps)
      {
        if (!String.IsNullOrEmpty(msgProps.MessageID))
          logMetadata.MessageId = msgProps.MessageID;
        if (!String.IsNullOrEmpty(msgProps.MsgSubject))
          logMetadata.Subject = msgProps.MsgSubject;
        if (!String.IsNullOrEmpty(msgProps.OSCISubject))
          logMetadata.MessageType = msgProps.OSCISubject;
        if (null != msgProps.AddresseeCertProps)
        {
          if (!String.IsNullOrEmpty(msgProps.AddresseeCertProps.Name))
            logMetadata.RecipientName = msgProps.AddresseeCertProps.Name;
        }
        if (null != msgProps.Originator && null != msgProps.Originator.BusinessCard)
        {
          if (!String.IsNullOrEmpty(msgProps.Originator.BusinessCard.UserID))
            logMetadata.Sender = msgProps.Originator.BusinessCard.UserID;
          if (!String.IsNullOrEmpty(msgProps.Originator.BusinessCard.Name))
            logMetadata.SenderName = msgProps.Originator.BusinessCard.Name;
        }
      }
    }

    // Logging Metadaten aufbereiten
    public void CreateLogMetadata(Message msg, ref LogMetadata logMetadata, string messageID = null, EgvpPostbox egvpPostbox = null)
    {
      EGVPMessageProps msgProps = null;
      string messageSizeKB = "";
      string messageSizeAttachmentsKB = "";
      string departmentCode = "";

      if (null == logMetadata)
        logMetadata = new LogMetadata();

      if (null != msg)
      {
        try { messageSizeKB = Convert.ToString((Convert.ToInt32(msg.MessageData.Length) / 1024)); }
        catch { messageSizeKB = ""; }
        try { messageSizeAttachmentsKB = Convert.ToString((GetAttachmentsSize(msg.MessageData) / 1024)); }
        catch { messageSizeAttachmentsKB = ""; }

        try
        {
          if (null != egvpPostbox && DepartmentsService.DepartmentsModeActive(egvpPostbox))
          {
            var depService = new DepartmentsService(egvpPostbox, msg.MessageData);
            departmentCode = depService.GetDepartmentId();
          }

          using (ZipArchive za = new ZipArchive(new MemoryStream(msg.MessageData)))
          {
            var ze = za.GetEntry("MsgProps.xml");
            if (null != ze)
            {
              using (var stream = ze.Open())
              {
                msgProps = EGVPMessageProps.LoadFromStream(stream);
              }
            }
          }
        }
        catch (Exception ex)
        {
          ExtendedLogMetadata(null, ref logMetadata, messageID, egvpPostbox, messageSizeKB, messageSizeAttachmentsKB, departmentCode);
          throw ex;
        }
      }

      ExtendedLogMetadata(msgProps, ref logMetadata, messageID, egvpPostbox, messageSizeKB, messageSizeAttachmentsKB, departmentCode);
    }

    // Logging Metadaten aufbereiten
    public void CreateLogMetadata(string zipFullFilename, ref LogMetadata logMetadata, string messageID = null, EgvpPostbox egvpPostbox = null)
    {
      EGVPMessageProps msgProps = null;
      string messageSizeKB = "";
      string messageSizeAttachmentsKB = "";

      if (!string.IsNullOrEmpty(zipFullFilename))
      {
        try { messageSizeKB = Convert.ToString((Convert.ToInt32(new FileInfo(zipFullFilename).Length) / 1024)); }
        catch { messageSizeKB = ""; }
        try { messageSizeAttachmentsKB = Convert.ToString((GetAttachmentsSize(File.ReadAllBytes(zipFullFilename)) / 1024)); }
        catch { messageSizeAttachmentsKB = ""; }

        using (ZipArchive za = ZipFile.OpenRead(zipFullFilename))
        {
          var ze = za.GetEntry("MsgProps.xml");
          using (var stream = ze.Open())
          {
            msgProps = EGVPMessageProps.LoadFromStream(stream);
          }
        }
      }

      ExtendedLogMetadata(msgProps, ref logMetadata, messageID, egvpPostbox, messageSizeKB, messageSizeAttachmentsKB);
    }

    // Hinweis auf einen Fehlerhaften Nachrichtenabruf in die Datenbank aufnehmen
    public static void CreateDBMessageErrorFlag(string messageID, string description)
    {
      try
      {
        using (var db = new APPDATAEntities())
        {
          var qry = from EgvpEnterpriseReceiver_Error in db.EgvpEnterpriseReceiver_Error
                    where EgvpEnterpriseReceiver_Error.MessageId == messageID
                    select EgvpEnterpriseReceiver_Error;
          EgvpEnterpriseReceiver_Error errData;

          if (qry.Count() > 0)
          { errData = qry.First(); }
          else
          { errData = new EgvpEnterpriseReceiver_Error() { MessageId = messageID }; }

          errData.Description = description;
          errData.TimeStamp = DateTime.Now;

          if (qry.Count() < 1) { db.EgvpEnterpriseReceiver_Error.Add(errData); }
          db.SaveChanges();
        }
      }
      catch (Exception ex)
      {
        Logger.Log(ex.Message, "CreateDBMessageErrorFlag: Fehler beim Erzeugen eines Fehlerhinweises zu Nachricht " + messageID, LogEventLevel.Warning);
      }
    }

    // Prüfen ob ein Fehlerhinweis zu einer Nachricht existiert und diese evtl. nicht abgerufen werden soll
    public static bool CheckDBMessageErrorFlag(string messageID, string waitingHours)
    {
      bool rval = false;

      try
      {
        using (var db = new APPDATAEntities())
        {
          var qry = from EgvpEnterpriseReceiver_Error in db.EgvpEnterpriseReceiver_Error
                    where EgvpEnterpriseReceiver_Error.MessageId == messageID
                    select EgvpEnterpriseReceiver_Error;

          if (qry.Count() > 0)
          {
            EgvpEnterpriseReceiver_Error errData = qry.First();

            Int32 waitHours = 0;
            if (!string.IsNullOrEmpty(waitingHours))
              waitHours = Convert.ToInt32(waitingHours);

            if (null != errData.TimeStamp && waitHours > 0)
            {
              DateTime cmp = errData.TimeStamp;
              if (DateTime.Compare(DateTime.Now, cmp.AddHours(waitHours)) < 0)
                rval = true;
            }
          }
        }
      }
      catch (Exception ex)
      {
        Logger.Log(ex.Message, "CheckDBMessageErrorFlag: Fehler beim Prüfen eines Fehlerhinweises zu Nachricht " + messageID, LogEventLevel.Warning);
      }
      return rval;
    }

    // MessageSizeAttachments ermitteln
    private int GetAttachmentsSize(byte[] messageZIP)
    {
      int size = 0;
      using (ZipArchive za = new ZipArchive(new MemoryStream(messageZIP), ZipArchiveMode.Read))
      {
        foreach (ZipArchiveEntry ze in za.Entries)
        {
          if (ze.FullName.StartsWith("attachments/"))
            size += Convert.ToInt32(ze.Length);
        }
      }
      return size;
    }

    // weitere Metadaten per Soap abrufen
    private void ExtendedLogMetadataFromState(string messageID, EgvpPostbox egvpPostbox, ref LogMetadata logMetadata)
    {
      try
      {
        MessageMetadata msgMeta = _messageSource.GetMessageMetadata(new MessageIdent { MessageId = messageID, ReceiverId = egvpPostbox.Id });
        logMetadata.Recipient = msgMeta.ReceiverId;
        logMetadata.Sender = msgMeta.SenderId;
        logMetadata.OsciState = msgMeta.State;
        logMetadata.OsciDatetime = msgMeta.Datetime;
      }
      catch (Exception ex)
      {
        Logger.Log(ex.Message, "ExtendedLogMetadataFromState: Fehler beim Abrufen des Nachrichtenstatus - MessageId: " + messageID, LogEventLevel.Warning);
      }
    }
  }
}