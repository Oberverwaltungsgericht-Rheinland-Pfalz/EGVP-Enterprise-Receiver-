﻿using OvgRlp.EgvpEpReceiver.Infrastructure.Contracts;
using OvgRlp.EgvpEpReceiver.Infrastructure.Models;
using OvgRlp.EgvpEpReceiver.Services;
using OvgRlp.Libs.Logging;
using OvgRlp.Libs.Logging.LogTypes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OvgRlp.EgvpEpReceiver.Test
{
  public class ReceiveMessageAtEgvpEnterprise_Test
  {
    /*         !!! Achtung !!!
     * Diese Tests erfordern eine Verbindung zum EGVP-Enterprise Webservice inkl. einer vorhandenen Nachricht.
     * Die Egvp-Enterprise Verbindungsdaten sind hier im Testprojekt in der app.config zu hinterlegen.
     * Weiterhin müssen die nachstehenden Konstanten mit Daten einer existierenden Nachricht angepasst werden,
     * ansonsten schlagen alle Tests fehl!
     */
    public const string MESSAGEID = "govapp_16415504009207836994752992925350";
    public const string SENDERID = "DE.Justiz.836d1e07-f830-4641-91ef-0a9c2d44b136.1c84";
    public const string RECEIVERID = "DE.Justiz.233a8870-6319-4d4c-8f79-a3bb8fa8f328.51b7";
    public const string OSCISTATE = "WS_RECEIVED";

    public const string TMP_PATH = @"tmp\unittest\";
    public const string LOGFILE = TMP_PATH + "Logfile.log";

    [Fact]
    public void Message_Receive_OK()
    {
      string logfile = Path.Combine(Helper.GetTestingPath(), LOGFILE);
      EgvpPostbox postbox = Helper.GetEgvpPostbox(Path.Combine(Helper.GetTestingPath(), TMP_PATH), RECEIVERID);
      var receiveService = new ReceiveMessageService(new MsgSrcEgvpEpWebservice(), postbox, "", Helper.PrepareTempDir(Path.Combine(Helper.GetTestingPath(), TMP_PATH)), "");

      Helper.InitTestLogger(logfile);
      receiveService.ReceiveMessage(MESSAGEID);
      Assert.True(Directory.Exists(Path.Combine(postbox.ExportPath[0], MESSAGEID)));
      Assert.True(Directory.Exists(Path.Combine(postbox.ArchivPath[0], MESSAGEID)));

      string logText = File.ReadAllText(logfile);
      Debug.WriteLine("--> Debug.WriteLine: " + logText);

      Assert.Contains("Nachricht wurde erfolgreich verarbeitet!", logText);
      Assert.DoesNotContain("ERR", logText);
      Assert.Contains("OsciState\\\":\\\"" + OSCISTATE, logText);
      Assert.Contains("Sender\\\":\\\"" + SENDERID, logText);
      Assert.Contains("Recipient\\\":\\\"" + RECEIVERID, logText);
      Assert.Contains("MessageId\\\":\\\"" + MESSAGEID, logText);
    }

    [Fact]
    public void Message_State_OK()
    {
      IMessageSource messageSource = new MsgSrcEgvpEpWebservice();
      MessageMetadata msgMeta = messageSource.GetMessageMetadata(new MessageIdent { MessageId = MESSAGEID, ReceiverId = RECEIVERID });

      Assert.Equal(OSCISTATE, msgMeta.State);
      Assert.False(string.IsNullOrEmpty(msgMeta.Datetime));
    }
  }
}