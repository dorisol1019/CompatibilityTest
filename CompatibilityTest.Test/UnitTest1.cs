using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bot.Interactive;
using System.IO;

namespace Bot.Interactive.Test

{
    [TestClass]
    public class CompatibilityTestTest
    {
        CompatibilityTest compatibilityTest;

        [TestInitialize]
        public void Initiallzer()
        {
            string path = "template.json";
            compatibilityTest = new CompatibilityTest(path);
            Assert.IsNotNull(compatibilityTest);
        }

        [TestMethod]
        public void GetBeginningMessagesTest()
        {
            var beginningMessages = compatibilityTest.GetBeginningMessages().ToArray();

            var expected = new[]
            {
                null as string
            };

            CollectionAssert.AreEqual(expected, beginningMessages);
        }

        [TestMethod]
        public void GetReplayQuestionTest()
        {
            var question = compatibilityTest.GetReplayQuestion();
            Core.Question expected = null;

            Assert.AreEqual(expected.Id, question.Id);
            Assert.AreEqual(expected.Text, question.Text);
            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(expected.AnswerOption[i].Type, question.AnswerOption[i].Type);
                
                Assert.AreEqual(expected.AnswerOption[i].NextId, question.AnswerOption[i].NextId);

                Assert.AreEqual(expected.AnswerOption[i].Label, question.AnswerOption[i].Label);
            }
        }

        [TestMethod]
        public void GetReplayMessagesTest()
        {
            var messages = compatibilityTest.GetReplayMessages().ToArray();
            string[] expected = new[]
            {
                null as string
            };
            CollectionAssert.AreEqual(expected, messages);
        }

        [TestMethod]
        public void GetEndingMessagesTest()
        {
            var messages = compatibilityTest.GetEndingMessages().ToArray();
            string[] expected = new[]
            {
                ""
            };
            CollectionAssert.AreEqual(expected, messages);
        }

        [TestMethod]
        public void GetResultMessagesTest()
        {
            var messages = compatibilityTest.GetResultMessages(2).ToArray();
            string[] expected = new[]
            {
                ""
            };
            CollectionAssert.AreEqual(expected, messages);
        }

        [TestMethod]
        public void GetResultMessagesTest2()
        {
            var messages = compatibilityTest.GetResultMessages(3).ToArray();
            string[] expected = new[]
            {
                ""
            };
            CollectionAssert.AreEqual(expected, messages);
        }

        [TestMethod]
        public void GetResultMessagesTest3()
        {
            var messages = compatibilityTest.GetResultMessages(5).ToArray();
            string[] expected = new[]
            {
                "" 
            };
            CollectionAssert.AreEqual(expected, messages);
        }

        public string GetResult(Core.AnswerOption answer)
        {
            var question = compatibilityTest.GetQuestion(answer.NextId);
            var option = question.AnswerOption[0];
            if (option.Type == Core.AnswerActionType.Result)
                return compatibilityTest.GetResultMessages(option.NextId).ElementAt(1);
            return GetResult(option);
        }
        
    }
}
