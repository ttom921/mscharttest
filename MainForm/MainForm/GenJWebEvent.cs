using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainForm
{
    public class GenJWebEvent
    {
        const int MAX_CHANNEL = 8;
        const int MAX_EVENT = 10;
        const int RandCountDay = 15;
        const int MAX_DAY = 2;
        Random random = new Random();
        List<JWebEventInfo> listData = new List<JWebEventInfo>();
        public GenJWebEvent()
        {
            //random.Next(0, MAX_EVENT);
        }
        public List<JWebEventInfo> GenTestData()
        {
            DateTime dtStartRnd = new DateTime(2019, 03, 29, 0, 0, 0); //00:00:00 AM
            for (int i = 0; i < MAX_DAY; i++)
            {
                //一天有多少個事件
                int countevent = random.Next(1,RandCountDay);
                for (int j = 0; j < countevent; j++)
                {
                    int year = dtStartRnd.Year;
                    int month = dtStartRnd.Month;
                    int day = dtStartRnd.Day;
                    int hour = random.Next(0, 24);
                    dtStartRnd = new DateTime(year, month, day, hour, 0, 0);
                    JWebEventInfo jWebEventInfo = new JWebEventInfo();
                    jWebEventInfo.record_channel = genchannel();
                    jWebEventInfo.uploaded_time = dtStartRnd;
                    int eventid = random.Next(0, MAX_EVENT); 
                    jWebEventInfo.event_type = $"event_type {eventid}";
                    jWebEventInfo.event_name = $"event_name {eventid}";
                    listData.Add(jWebEventInfo);
                }
                dtStartRnd=dtStartRnd.AddDays(1);
                //
            }
            return listData;
            //JWebEventInfo jWebEventInfo = new JWebEventInfo();
            //jWebEventInfo.record_channel = genchannel();
            //int eventid = 0;
            //jWebEventInfo.event_type = $"event_type {eventid}";
            //jWebEventInfo.event_name = $"event_name {eventid}";


        }
        JWebEventInfo.Eventinfo_RecordChannel[]  genchannel()
        {
            JWebEventInfo.Eventinfo_RecordChannel[] eventinfo_RecordChannels = new JWebEventInfo.Eventinfo_RecordChannel[8];
            for (int i = 0; i < MAX_CHANNEL; i++)
            {
                JWebEventInfo.Eventinfo_RecordChannel eventinfo_RecordChannel = new JWebEventInfo.Eventinfo_RecordChannel();
                eventinfo_RecordChannel.ch = i;
                eventinfo_RecordChannel.picture = $"ch_{eventinfo_RecordChannel.ch} 的picture";
                eventinfo_RecordChannels[i] = eventinfo_RecordChannel;
            }
            return eventinfo_RecordChannels;
        }
    }
}
