using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SqlToElasticSearchConverter {



    public class Templates {
        public const string SingleCondition = @"
                {
                      ""match"": {
                        ""(column)"": ""(value)""
                      }
                }
            ";



        public const string InCondition = @"
                {
                      ""terms"": {
                        ""(column)"": [(value)]
                      }
                }
            ";

        public const string BetweenCondition = @"
                {
                      ""range"": {
                        ""(column)"": {
                            ""gte"": ""(lowerValue)"",
                            ""lte"": ""(upperValue)""
                        }                            
                      }
                }
            ";

        public const string ComparisonCondition = @"
                {
                      ""range"": {
                        ""(column)"": {
                            ""(operator)"": ""(value)""
                        }                            
                      }
                }
            ";

        public const string LikeCondition = @"
                {
                      ""wildcard"": {
                        ""(column)"": ""(value)""
                      }
                }
            ";

        public const string Conditions = @"""query"": {
                ""bool"": {
                    ""must"": [
                        (conditions)
                    ]
                }
            }";

        public const string GroupBy = @"
              ""aggregations"": {
                ""(column)"": {
                  ""terms"": { ""field"": ""(column).keyword"" }(additionalAggregation)
                }
              }";

        public static string SizeZero => @"""size"": 0";
    }
}
