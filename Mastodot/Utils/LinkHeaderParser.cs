﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Mastodot.Entities;

namespace Mastodot.Utils
{
    internal class LinkHeaderParser
    {
        private static readonly string MAXID = "max_id";
        private static readonly string SINCEID = "since_id";
        private static readonly string OPERATOR_NEXT = "next";
        private static readonly string OPERATOR_PREV = "prev";
        private static readonly string LINKPATTERN = "<(?<url>.*)>; *rel=\\\"(?<operator>.*)\\\"";

        // example: 
        // <https://mastodon.cloud/api/v1/timelines/public?max_id=3092746>; rel="next", <https://mastodon.cloud/api/v1/timelines/public?since_id=3092777>; rel="prev"
        public static LinkHeader GetHeader(string header)
        {
            var headerGroup = GetUrlsOperation(header);
            string next = null;
            string prev = null;

            string tmp;
            if (headerGroup.TryGetValue(OPERATOR_NEXT, out tmp))
            {
                var queries = QueryParser(tmp);
                next = GetNextId(queries);
            }
            if (headerGroup.TryGetValue(OPERATOR_PREV, out tmp))
            {
                var queries = QueryParser(tmp);
                prev = GetPrevId(queries);
            }

            return new LinkHeader
            {
                Next = next,
                Prev = prev
            };
        }

        private static IDictionary<string, string> GetUrlsOperation(string header)
        {
            var re = new Regex(LINKPATTERN, RegexOptions.IgnoreCase);
            var headers = header.Split(',').Select(s => s.Trim());
            var headerPair = new Dictionary<string, string>();

            foreach (var h in headers)
            {
                var match = re.Match(h);
                if (!match.Success)
                {
                    continue;
                }

                headerPair.Add(match.Groups["operator"].ToString().ToLower(), match.Groups["url"].ToString().ToLower());
            }

            return headerPair;
        }

        private static string GetNextId(IDictionary<string, string> header)
        {
            string id = "";
            if (header?.TryGetValue(MAXID, out id) == true)
            {
                return id;
            }

            return id;
        }

        private static string GetPrevId(IDictionary<string, string> header)
        {
            string id = "";
            if (header?.TryGetValue(SINCEID, out id) == true)
            {
                return id;
            }

            return id;
        }

        private static IDictionary<string, string> QueryParser(string header)
        {
            var queryIndex = header.IndexOf('?');
            if (queryIndex == -1) return null;

            return header.Remove(0, queryIndex + 1)
                .Split('&').Select(q => q.Split('=')).Where(kvp => kvp.Length == 2).ToDictionary(k => k[0], v => v[1]);
        }
    }
}
