using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using HtmlAgilityPack;

namespace GetScoreMatch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        StreamReader sr;
        Regex regex = new Regex(">(.+)<\\/p>[.+|\n+].+[\n]{4}.+\n.+\n.+>(.+)<.+\n.+\n.+>(.+)<.+\n{2}.+>(.+)<.+\n.+\n{4}.+\n{2}.+\n.+\n.+p>(.+)<");

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "https://www.yallakora.com/match-center/%D9%85%D8%B1%D9%83%D8%B2-%D8%A7%D9%84%D9%85%D8%A8%D8%A7%D8%B1%D9%8A%D8%A7%D8%AA?date=" + numericM.Value + "/" + numericD.Value + "/" + DateTime.Now.Year + "#days";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(textBox1.Text);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                sr = new StreamReader(response.GetResponseStream());
                richTextBox1.Text = sr.ReadToEnd();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Erorr.. Contact With Us !! / Enter Correct Date");
                Application.Exit();
            }

            printDocument1.Print();
        }




        int i = 0;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var HTMLSourceCode = GetRegex(richTextBox1.Text).Skip(i);
            if (HTMLSourceCode.Count() == 0)
            {
                MessageBox.Show("No Matches Were Held.. ");
                return;
            }

            Font f = new Font("Arial", 16);
            Font ff = new Font("Arial", 22);
            int y = 20;
            int yy = 20;
            int yyy = 20;
            string projectPath = Directory.GetParent(Application.StartupPath).Parent.Parent.FullName;
            string imagePath = Path.Combine(projectPath, "images/logo.png");

            
            foreach (var item in HTMLSourceCode)
            {
                e.Graphics.DrawString(item.Leauge, f, Brushes.Black, 540, 10 );
                foreach (var c in item.InnerInformation)
                {
                    e.Graphics.DrawString(c.Week, new Font("Arial",22,FontStyle.Bold), Brushes.Black, 40, 10 );
                    e.Graphics.DrawString(c.ScoreB, ff, Brushes.Black, 330, 30 + y);
                    e.Graphics.DrawString(c.TeamB, f, Brushes.Black, 160, 38 + yy);
                    e.Graphics.DrawString(c.Time, f, Brushes.DimGray, 380, 30 + y);
                    e.Graphics.DrawString(c.TeamA, f, Brushes.Black, 530, 38 + yy);
                    e.Graphics.DrawString(c.ScoreA, ff, Brushes.Black, 460, 30 + y);
                    e.Graphics.DrawLine(Pens.LightGray, 0, 70 + yyy, 1000, 70 + yyy);
                    e.Graphics.DrawImage(Image.FromFile(projectPath), 13, 1115, 100, 41);
                    y += 68;
                    yy += 68;
                    yyy += 68;
                }
                i += 1;

                if (HTMLSourceCode.Count() != 1)
                {
                    e.HasMorePages = true;
                    break;
                }
                else { i = 0; }
            }

        }

        List<OuteInformation> GetRegex(string Response)
        {
            string html = Response;
            List<OuteInformation> Leauges = new List<OuteInformation>();

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            HtmlNodeCollection rows = doc.DocumentNode.SelectNodes("//div[contains(@class, 'matchCard') and contains(@class, 'matchesList')]");

            if (rows != null)
            {
                foreach (var node in rows)
                {

                    var titleLeauge = Regex.Match(node.OuterHtml, @"<h2>\s*(.*?)\s*<\/h2>");
                    string tournament = titleLeauge.Success ? titleLeauge.Groups[1].Value : "غير موجود";

                    var picLeauge = Regex.Match(node.OuterHtml, "https:\\/\\/media\\.gemini\\.media\\/img\\/yallakora\\/Tourlogo\\/[^\\s\"\"']+");
                    string pic = picLeauge.Success ? picLeauge.Groups[1].Value : "غير موجود";

                    //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(textBox1.Text);
                    //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    //if (!Directory.Exists("Pictures")){ Directory.CreateDirectory("Pictures"); }


                    HtmlAgilityPack.HtmlDocument docChild = new HtmlAgilityPack.HtmlDocument();
                    docChild.LoadHtml(node.OuterHtml);
                    HtmlNodeCollection rowPartial = docChild.DocumentNode.SelectNodes("//div[contains(@class, 'allData')]");
                    List<InnerInformation> Matches = new List<InnerInformation>();

                    foreach (var c in rowPartial)
                    {
                        var weekLeauge = Regex.Match(node.OuterHtml, @"<div class=""date"">\s*(.*?)\s*<\/div>");
                        string week = weekLeauge.Success ? weekLeauge.Groups[1].Value : "غير موجود";

                        var teamMatches = Regex.Matches(c.OuterHtml, @"<p>\s*(.+)\s*<\/p>");
                        List<string> teams = new List<string>();
                        foreach (Match match in teamMatches) { teams.Add(match.Groups[1].Value); }

                        var timeMatch = Regex.Match(c.OuterHtml, @"<span class=""time"">\s*(\d{1,2}:\d{2})\s*<\/span>");
                        string matchTime = timeMatch.Success ? timeMatch.Groups[1].Value : "غير موجود";

                        var scoreMatches = Regex.Matches(c.OuterHtml, "<span class=\"score\">([\\-0-9]+)<\\/span");
                        List<string> scores = new List<string>();
                        foreach (Match match in scoreMatches) { scores.Add(match.Groups[1].Value); }


                        Matches.Add(new InnerInformation { TeamA = teams[0], TeamB = teams[1], ScoreA = scores[0], ScoreB = scores[1], Time = matchTime, Week = week });
                    }
                    Leauges.Add(new OuteInformation { Leauge = tournament, Pictures = picLeauge.Value, InnerInformation = Matches });
                }
                return Leauges;
            }
            else
            {
                MessageBox.Show("❌ No Matches Were Held..");
                return Leauges = null;
            }
        }
    }

    internal class OuteInformation
    {
        public string Leauge { get; set; }
        public string Pictures { get; set; }
        public List<InnerInformation> InnerInformation { get; set; }
    }

    internal class InnerInformation
    {
        public string Week { get; set; }
        public string Time { get; set; }
        public string TeamA { get; set; }
        public string TeamB { get; set; }
        public string ScoreA { get; set; }
        public string ScoreB { get; set; }
    }
}
    

//keep learning...
