using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SamuraiDojo.Attributes;
using SamuraiDojo.Stats;
using SamuraiDojo.Test;
using SamuraiDojo.Utility;

namespace SamuraiDojo.ScoreBoard
{
    public partial class MainBoard : Form
    {
        public MainBoard()
        {
            InitializeComponent();
            RunTests();
            currentChallengeLabel.Text = $"'{GetCurrentChallengeName()}'";
        }

        public void RunTests()
        {
            TestRunner testRunner = new TestRunner();
            testRunner.OnTestPass = (context) =>
            {
                ScoreKeeper.AddPoint(context.WrittenBy, context.ClassUnderTest);
            };
            testRunner.Run();
        }

        public string GetCurrentChallengeName()
        {
            Type currentChallenge = ScoreKeeper.CurrentChallenge;
            ChallengeAttribute attribute = AttributeUtility.GetAttribute<ChallengeAttribute>(currentChallenge);

            return attribute.Name;
        }
    }
}
