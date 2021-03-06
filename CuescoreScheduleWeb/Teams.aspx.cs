﻿using CuescoreSchedule;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using League = CuescoreSchedule.League;

namespace CuescoreScheduleWeb
{
    public partial class _Teams : Page
    {
        private CuescoreParser parser;
        private HtmlDocument leagueDocument;
        public string LeagueID;

        protected void Page_Load(object sender, EventArgs e)
        {
            parser = new CuescoreParser();
            if (Request.Url.Segments.Count() >= 3)
            {
                LeagueID = Request.Url.Segments[2];
                leagueDocument = parser.GetLeagueDocument(LeagueID);
            }
        }

        protected List<string> GetTeams()
        {
            return parser.GetTeams(leagueDocument);
        }

        protected string UrlEncode(string team)
        {
            return HttpUtility.UrlEncode(team).Replace(".", "DOT");
        }
    }
}