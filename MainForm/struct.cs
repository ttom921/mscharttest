
	#region [ :: JWebEventInfo 結構表 (事件資訊) :: ]
    /// <summary>
    /// JackWeb API (Event info) response
    /// </summary>
    public class JWebEventInfo
    {
        public Eventinfo_RecordChannel[] record_channel { get; set; }
        public float speed { get; set; }
        public System.DateTime uploaded_time { get; set; }
        public int company_id { get; set; }
        public float gps_altitude { get; set; }
        public int gps_sat_num { get; set; }
        public int event_start_time { get; set; }
        public string event_type { get; set; }
        public float gps_latitude { get; set; }
        public int? event_issue_ms { get; set; }            
        public float heading { get; set; }
        public string car_uid { get; set; }
        public string event_name { get; set; }              //! 事件名稱
        public int? gop_total { get; set; }
        public bool gps_fix { get; set; }
        public string dvr_uid { get; set; }
        public string event_media_type { get; set; }        //! 模體模式
        public int? gop_count { get; set; }                 //! GOP count
        public int dvr_id { get; set; }                     //!< DVR ID
        public int id { get; set; }                         //!< Event ID
        public int event_end_time { get; set; }
        public string event_video_status { get; set; }
        public int event_issue_time { get; set; }
        public string description { get; set; }
        public int car_id { get; set; }
        public float gps_longitude { get; set; }

        public class Eventinfo_RecordChannel
        {
            public int ch { get; set; }             //!< Channel number
            public string picture { get; set; }     //!< Picture url addres
        }
    }
    #endregion
	