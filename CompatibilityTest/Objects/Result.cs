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

using System;
using Newtonsoft.Json;

namespace Bot.Interactive.Core
{

    public class Result
    {
        [JsonIgnore]
        private static string _defaultMessage;

        [JsonProperty("defaultResultMessage")]
        [JsonIgnore]
        public static string DefaultMessage
        {
            get
            {
                if (string.IsNullOrEmpty(_defaultMessage))
                {
                    throw new NullReferenceException($"{nameof(DefaultMessage)}をNullにすることはできません");
                }
                return _defaultMessage;
            }
            set => _defaultMessage = value;
        }

        [JsonProperty("id")]
        [JsonRequired]
        public int Id { get; set; }
        //相手の本名
        [JsonProperty("name")]
        [JsonRequired]
        public string Name { get; set; }

        //自分から見た相手の名前
        [JsonProperty("nickname")]
        [JsonRequired]
        public string Nickname { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonConstructor]
        public Result(int id, string name, string nickname, string message)
        {
            Id = id;
            Name = name;
            Nickname = nickname;
            Message = message ?? DefaultMessage;
        }

        public Result(int id, string name, string nickname)
        {
            Id = id;
            Name = name;
            Nickname = nickname;
            Message = DefaultMessage;
        }
        
        public string GetMessage()
        {
            var text = Message.Replace("{nickname}", Nickname);
            return text;
        }
    }
}
