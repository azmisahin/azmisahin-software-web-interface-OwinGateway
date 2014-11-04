﻿using System;
using System.Collections.Generic;
namespace OwinGate
{
    public class Page
    {
        /// <summary>
        /// Gateway Offline Front page
        /// </summary>
        /// <returns></returns>
        public static string Offline()
        {
            string ret = string.Empty;
            #region Default Html Template
            ret = "" +
            "<!DOCTYPE html>" +
            "<html lang='en'>" +
            "<head>" +
            "<meta charset='utf-8'>" +
            "<meta http-equiv='X-UA-Compatible' content='IE=edge'>" +
            "<meta name='viewport' content='width=device-width, initial-scale=1.0'>" +
            "<meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>" +
            "<meta http-equiv='Page-Enter' content='blendTrans(Duration=0.2)'>" +
            "<meta http-equiv='Page-Exit' content='blendTrans(Duration=0.2)'>" +
            "<meta name='description' content=''>" +
            "<meta name='author' content='bilgi@azmisahin.com'>" +
            //"<meta http-equiv='refresh' content='10;URL='>" +
            "<meta name='google' content='notranslate' />" +
            "<link href='//netdna.bootstrapcdn.com/bootstrap/3.0.3/css/bootstrap.min.css' rel='stylesheet'>" +
            "<!--[if lt IE 9]>" +
            "<script src='https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js'></script>" +
            "<script src='https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js'></script>" +
            "<![endif]-->" +
            "<title>Şuan Bakım Çalışmasındayız!</title>" +
            "<style type='text/css'>" +
            "*               {   margin: 0px;  padding: 0px;  outline: 0;}" +
            "header          {   text-align: center;  margin-top: 120px;}" +
            "header .logo    {   margin-bottom: 40px;}" +
            "header h3       {   font-family: Georgia, 'Times New Roman', Times, serif;  font-size: 45px;  font-style: italic;  color: #333;}" +
            "section         {   text-align: center;  margin-top: 50px;  font-family: Georgia, 'Times New Roman', Times, serif;  font-style: italic;}" +
            "section.desc    {   font-size: 25px;  color: #999;}" +
            "section.social  {   font-size: 14px;  color: #999;}" +
            "footer          {   margin-top: 40px;}" +
            "footer img      {   margin-right: 10px;}" +
            "</style>" +
            "</head>" +
            "<body>" +
            "<header>" +
            "<h3>Sistemlerimiz bakımdadır.</h3>" +
            "</header>" +
            "<section class='desc'>" +
            "<img id='bakim' src='data:image/gif;base64,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' alt=''>" +
            "</section>" +
            "<section class='desc'>" +
            "Lütfen daha sonra tekrar deneyiniz. <br> anlayışınız için teşekkür ederiz..." +
            "</section>" +
            "<script src='https://code.jquery.com/jquery-1.10.2.min.js'></script>" +
            "<script type='text/javascript' src='//netdna.bootstrapcdn.com/bootstrap/3.0.3/js/bootstrap.min.js'></script>" +
            "</body>" +
            "</html>" +
            "";
            #endregion
            return ret;
        }

        /// <summary>
        /// Gateway Default Routing Page
        /// </summary>
        /// <returns></returns>
        public static string Welcome()
        {
            string ret = string.Empty;
            #region Default Html Template
            ret = "" +
            "<!DOCTYPE html>" +
            "<html lang='en'>" +
            "<head>" +
            "<meta charset='utf-8'>" +
            "<meta http-equiv='X-UA-Compatible' content='IE=edge'>" +
            "<meta name='viewport' content='width=device-width, initial-scale=1.0'>" +
            "<meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>" +
            "<meta http-equiv='Page-Enter' content='blendTrans(Duration=0.2)'>" +
            "<meta http-equiv='Page-Exit' content='blendTrans(Duration=0.2)'>" +
            "<meta name='description' content=''>" +
            "<meta name='author' content='bilgi@azmisahin.com'>" +
            //"<meta http-equiv='refresh' content='10;URL='>" +
            "<meta name='google' content='notranslate' />" +
            "<link href='//netdna.bootstrapcdn.com/bootstrap/3.0.3/css/bootstrap.min.css' rel='stylesheet'>" +
            "<!--[if lt IE 9]>" +
            "<script src='https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js'></script>" +
            "<script src='https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js'></script>" +
            "<![endif]-->" +
            "<title>Hoşgeldiniz!</title>" +
            "<style type='text/css'>" +
            "*               {   margin: 0px;  padding: 0px;  outline: 0;}" +
            "header          {   text-align: center;  margin-top: 120px;}" +
            "header .logo    {   margin-bottom: 40px;}" +
            "header h3       {   font-family: Georgia, 'Times New Roman', Times, serif;  font-size: 45px;  font-style: italic;  color: #333;}" +
            "section         {   text-align: center;  margin-top: 50px;  font-family: Georgia, 'Times New Roman', Times, serif;  font-style: italic;}" +
            "section.desc    {   font-size: 25px;  color: #999;}" +
            "section.social  {   font-size: 14px;  color: #999;}" +
            "footer          {   margin-top: 40px;}" +
            "footer img      {   margin-right: 10px;}" +
            "</style>" +
            "</head>" +
            "<body>" +
            "<header>" +
            "<h3>Geçit'e Hoşgeldiniz.</h3>" +
            "</header>" +
            "<section class='desc'>" +
            "Geçit şu an aktif durumda..." +
            "</section>" +
            "<script src='https://code.jquery.com/jquery-1.10.2.min.js'></script>" +
            "<script type='text/javascript' src='//netdna.bootstrapcdn.com/bootstrap/3.0.3/js/bootstrap.min.js'></script>" +
            "</body>" +
            "</html>" +
            "";
            #endregion
            return ret;
        }

        /// <summary>
        /// Gateway Request and Response Cominication Record
        /// </summary>
        /// <returns></returns>
        public static string Statics()
        {
            string ret = string.Empty;
            #region Default Html Template
            ret = "" +
            "<!DOCTYPE html>" +
            "<html lang='en'>" +
            "<head>" +
            "<meta charset='utf-8'>" +
            "<meta http-equiv='X-UA-Compatible' content='IE=edge'>" +
            "<meta name='viewport' content='width=device-width, initial-scale=1.0'>" +
            "<meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>" +
            "<meta http-equiv='Page-Enter' content='blendTrans(Duration=0.2)'>" +
            "<meta http-equiv='Page-Exit' content='blendTrans(Duration=0.2)'>" +
            "<meta name='description' content=''>" +
            "<meta name='author' content='bilgi@azmisahin.com'>" +
            "<meta http-equiv='refresh' content='10;URL='>" +
            "<meta name='google' content='notranslate' />" +
            "<link href='//netdna.bootstrapcdn.com/bootstrap/3.0.3/css/bootstrap.min.css' rel='stylesheet'>" +
            "<!--[if lt IE 9]>" +
            "<script src='https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js'></script>" +
            "<script src='https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js'></script>" +
            "<![endif]-->" +
            "<title>Statics!</title>" +
            "<style type='text/css'>" +
            "*               {   margin: 0px;  padding: 0px;  outline: 0;}" +
            "header          {   text-align: center;  margin-top: 20px;}" +
            "header h3       {   font-family: Georgia, 'Times New Roman', Times, serif;  font-size: 45px;  font-style: italic;  color: #333;}" +
            "section         {   text-align: center;  margin-top: 50px;  font-family: Georgia, 'Times New Roman', Times, serif;  font-style: italic;}" +
            "section.desc    {   font-size: 12px;  color: #3F3F3F; margin-left:auto; margin-right:auto; text-align:left; width:100%;}" +
            ".row            {      }" +
            ".row .col        {  width:12%; float:left;     }" +
            "footer          {   margin-top: 40px;}" +
            "footer img      {   margin-right: 10px;}" +
            "</style>" +
            "</head>" +
            "<body>" +
            "<header>" +
            "<h4>" + DateTime.Now.ToShortDateString() + " Geçit İstatistikleri." + "</h4>" +
            "</header>" +
            "<section class='desc'>" +
            Log2Html()+
            "</section>" +
            "<script src='https://code.jquery.com/jquery-1.10.2.min.js'></script>" +
            "<script type='text/javascript' src='//netdna.bootstrapcdn.com/bootstrap/3.0.3/js/bootstrap.min.js'></script>" +
            "</body>" +
            "</html>" +
            "";
            #endregion
            return ret;
        }

        /// <summary>
        /// Reading Log To Html Format
        /// </summary>
        /// <returns></returns>
        private static string Log2Html()
        {
            string ret = "" +
                "<table class='table table-striped'>" +
                "<thead>" +
                "<tr>" +
                "<th>zaman</th>" +
                "<th>ip</th>" +
                "<th>path</th>" +
                "</tr>" +
                "</thead>" +
                "<tbody>";

            List<OwinGate.Logger.Options> logs = OwinGate.Logger.ReadLog();
            for (int x= logs.Count; x>0;x--)
            {
                Logger.Options item = logs[x-1];
                ret += "" +
                    "<tr>" +
                    "<th>" + item.tarih + "</th>" +
                    "<th>" + item.ip + "</th>" +
                    "<th>" + item.path + "</th>" +
                    "</tr>";
            }
            ret += "" +
                "</tbody>" +
                "</table>";
            return ret;
        }
    }
}