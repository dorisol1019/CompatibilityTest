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
using System.Collections.Generic;

namespace Bot.Interactive.Core
{
    [JsonObject("character")]
    public class Character
    {
        [JsonRequired]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonRequired]
        [JsonProperty("questions")]
        public IEnumerable<Question> Questions { get; set; }

        [JsonRequired]
        [JsonProperty("defaultResultMessage")]
        public string DefaultResultMessage
        {
            get => _defaultResultMessage;
            set => _defaultResultMessage = Result.DefaultMessage = value;
        }

        [JsonIgnore]
        private string _defaultResultMessage;

        [JsonRequired]
        [JsonProperty("results")]
        public IEnumerable<Result> Results { get; set; }

        [JsonRequired]
        [JsonProperty("beginningMessages")]
        public IEnumerable<string> BeginningMessages { get; set; }

        [JsonRequired]
        [JsonProperty("replayMessages_firstHalf")]
        public IEnumerable<string> ResultMessages_firstHalf { get; set; }

        [JsonRequired]
        [JsonProperty("replayMessages_latterHalf")]
        public IEnumerable<string> ResultMessages_latterHalf { get; set; }

        [JsonRequired]
        [JsonProperty("replayQuestion")]
        public Question ReplayQuestion { get; set; }

        [JsonRequired]
        [JsonProperty("replayMessages")]
        public IEnumerable<string> ReplayMessages { get; set; }

        [JsonRequired]
        [JsonProperty("endingMessages")]
        public IEnumerable<string> EndingMessages { get; set; }
    }
}
