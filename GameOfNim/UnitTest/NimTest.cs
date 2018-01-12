﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfNim;
namespace UnitTest
{
    [TestClass]
    public class NimTest
    {
        MainWindow mw = new MainWindow();
        
        [TestMethod]
        public void PlayerRotationIsPlayer1TurnFalseExpected()
        {
            bool expectedResult = false;
            mw.isPlayer1Turn = true;
            mw.PlayerRotation();
            Assert.AreEqual(expectedResult, mw.isPlayer1Turn);
            
        }
        [TestMethod]
        public void PlayerRotationIsPlayer1TurnTrueExpected()
        {
            bool expectedResult = true;
            mw.isPlayer1Turn = false;
            mw.PlayerRotation();
            Assert.AreEqual(expectedResult, mw.isPlayer1Turn);

        }
        [TestMethod]
        public void ComputerTurnMatchRemainingMinus1()
        {
            mw.matchesRemaining = 5;
            mw.ComputerTurn();
            Assert.IsTrue(mw.matchesRemaining == 4);
        }
        [TestMethod]
        public void EasyPVPComputerTurnRow1MatchRemainingMinus1()
        {          
            mw.isPVP = false;
            mw.difficulty = "Easy";
            mw.SetUp();
            mw.ComputerTurn();
            Assert.IsTrue(mw.row1MatchesLeft == 2);
        }
        [TestMethod]
        public void MediumPVCComputerTurnRow1MatchRemainingMinus1()
        {
            mw.isPVP = false;
            mw.difficulty = "Medium";
            mw.SetUp();
            mw.ComputerTurn();
            Assert.IsTrue(mw.row1MatchesLeft == 1);
        }
        [TestMethod]
        public void HardPVCComputerTurnRow1MatchRemainingMinus1()
        {
            mw.isPVP = false;
            mw.difficulty = "Hard";
            mw.SetUp();
            mw.ComputerTurn();
            Assert.IsTrue(mw.row1MatchesLeft == 1);
        }
        [TestMethod]
        public void HardPVCComputerTurnRow2MatchRemainingMinus1()
        {
            mw.isPVP = false;
            mw.difficulty = "Hard";
            mw.SetUp();
            mw.row1MatchesLeft = 0;
            mw.ComputerTurn();
            Assert.IsTrue(mw.row2MatchesLeft == 2);
        }
        [TestMethod]
        public void HardPVCComputerTurnRow3MatchRemainingMinus1()
        {
            mw.isPVP = false;
            mw.difficulty = "Hard";
            mw.SetUp();
            mw.row1MatchesLeft = 0;
            mw.row2MatchesLeft = 0;
            mw.ComputerTurn();
            Assert.IsTrue(mw.row3MatchesLeft == 7);
        }
        [TestMethod]
        public void HardPVCComputerTurnRow4MatchRemainingMinus1()
        {
            mw.isPVP = false;
            mw.difficulty = "Hard";
            mw.SetUp();
            mw.row1MatchesLeft = 0;
            mw.row2MatchesLeft = 0;
            mw.row3MatchesLeft = 0;
            mw.ComputerTurn();
            Assert.IsTrue(mw.row4MatchesLeft == 8);
        }
        [TestMethod]
        public void ComputerTurn1MatchRemaining()
        {
            mw.isPVP = false;
            mw.difficulty = "Hard";
            mw.SetUp();
            int row1LblCount = mw.row1labels.Count;
            mw.ComputerTurn();
            Assert.IsTrue(mw.row1labels.Count == row1LblCount-1);
        }
        [TestMethod]
        public void Row1BtnClickedMatchesRemainingMinus1()
        {
            mw.isPVP = false;
            mw.difficulty = "Hard";
            mw.SetUp();
            mw.Row_one_btn_Click(null, null);
            Assert.IsTrue(mw.matchesRemaining == 21);
            
        }
        [TestMethod]
        public void Yes_ClickRow1MatchReset()
        {
            int expectedResult = 0;
            mw.Yes_Click(null, null);
            Assert.IsTrue(expectedResult == mw.row1MatchesLeft);
        }
        [TestMethod]
        public void Yes_ClickRow2MatchReset()
        {
            int expectedResult = 0;
            mw.Yes_Click(null, null);
            Assert.IsTrue(expectedResult == mw.row2MatchesLeft);
        }
        [TestMethod]
        public void Yes_ClickRow3MatchReset()
        {
            int expectedResult = 0;
            mw.Yes_Click(null, null);
            Assert.IsTrue(expectedResult == mw.row3MatchesLeft);
        }
        [TestMethod]
        public void Yes_ClickRow4MatchReset()
        {
            int expectedResult = 0;
            mw.Yes_Click(null, null);
            Assert.IsTrue(expectedResult == mw.row4MatchesLeft);
        }
        [TestMethod]
        public void YesisPVPReset()
        {
            bool expectedResult = false;
            mw.Yes_Click(null, null);
            Assert.IsTrue(expectedResult == mw.isPVP);
        }
        [TestMethod]
        public void YesisPlayer1TurnReset()
        {
            bool expectedResult = true;
            mw.Yes_Click(null, null);
            Assert.IsTrue(expectedResult == mw.isPlayer1Turn);
        }
        [TestMethod]
        public void YesisMatchTakenReset()
        {
            bool expectedResult = false;
            mw.Yes_Click(null, null);
            Assert.IsTrue(expectedResult == mw.matchTaken);
        }

    }
}