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

using Newtonsoft.Json;

namespace Bot.Interactive.Core
{
    public class Question
    {
        [JsonRequired]
        [JsonProperty("id")]
        public int Id { get; }

        [JsonProperty("text")]
        [JsonRequired]
        public string Text { get; }

        [JsonRequired]
        [JsonProperty("answerOption")]
        public AnswerOption[] AnswerOption { get; }

        public Question(int id, string text, AnswerOption[] answerOption)
        {
            Id = id;
            Text = text;
            AnswerOption = answerOption;
        }
    }
}
