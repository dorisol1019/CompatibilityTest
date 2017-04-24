// The MIT License (MIT)
//
// CompatibilityTest - A .NET Bot Interactive Library supporting .NET Standerd 1.3
// Copyright (c) 2017 dorisol1019
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.


using Bot.Interactive.Core;
using System;
using System.Collections.Generic;

using System.Linq;
using Newtonsoft.Json;
using System.IO;


namespace Bot.Interactive
{
    public class CompatibilityTest
    {
        private Character _character;
        
        public CompatibilityTest(string path)
        {
            if (!File.Exists(path)) throw new FileNotFoundException();
            string str = "";
            using (StreamReader sr = new StreamReader(new FileStream(path, FileMode.Open)))
            {
                str = sr.ReadToEnd();
            }
            _character = JsonConvert.DeserializeObject<Character>(str);
        }

        public Question GetQuestion(int id)
        {
            var nextQuestion = _character?.Questions?.FirstOrDefault(e => e.Id == id);

            return nextQuestion ??
                throw new NullReferenceException("Idの一致するQuestionがありません。");
        }

        public Question GetReplayQuestion()
        {
            return _character?.ReplayQuestion ??
                throw new NullReferenceException("ReplayQuestionがありません。");
        }


        private string GetResultMesssage(int id)
        {
            var result = _character?.Results?.FirstOrDefault(e => e.Id == id);

            return result?.GetMessage() ??
                throw new NullReferenceException("Idの一致するResultがありません。");
        }

        public IEnumerable<string> GetBeginningMessages()
        {
            return _character?.BeginningMessages;
        }

        public IEnumerable<string> GetEndingMessages()
        {
            return _character.EndingMessages;
        }

        public IEnumerable<string> GetReplayMessages()
        {
            return _character.ReplayMessages;
        }

        public IEnumerable<string> GetResultMessages(int id)
        {
            var resultmessages = new List<string>(_character.ResultMessages_firstHalf);

            var result = GetResultMesssage(id);
            resultmessages.Add(result);

            resultmessages.AddRange(_character.ResultMessages_latterHalf);

            return resultmessages;
        }
        
    }
}
