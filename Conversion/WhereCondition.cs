using System.Collections.Generic;

namespace SqlToElasticSearchConverter {
    public class WhereCondition {
        private List<string> inValues = new List<string>();
        private List<string> betweenValues = new List<string>();
        private string singularValue = string.Empty;

        public enum LiteralType {
            Numeric,
            String,
            Boolean
        }

        public enum OperatorType {
            Equal,
            GreaterThan,
            GreaterThanOrEquals,
            LessThan,
            LessThanOrEquals,
            In,
            Between,
            Unknown,
            Like
        }

        public string Column { get; set; } = null;
        public LiteralType Type { get; set; }
        public OperatorType Operator { get; set; }

        public string Value {
            set {
                string trimmedValue = value.Trim('\'');

                switch (Operator) {
                    case OperatorType.Equal:
                    case OperatorType.GreaterThan:
                    case OperatorType.GreaterThanOrEquals:
                    case OperatorType.LessThan:
                    case OperatorType.LessThanOrEquals:
                        singularValue = trimmedValue;
                        break;
                    case OperatorType.In:
                        inValues.Add(trimmedValue);
                        break;
                    case OperatorType.Between:
                        betweenValues.Add(trimmedValue);
                        break;
                    case OperatorType.Like:
                        singularValue = trimmedValue;
                        break;
                }
            }
        }

        public List<string> InValues {
            get {
                return inValues;
            }
        }

        public List<string> BetweenValues {
            get {
                return betweenValues;
            }
        }

        public string SingularValue {
            get {
                return singularValue;
            }
        }

        public bool IsComplete {
            get {
                return Column != null && (SingularValue != null || BetweenValues.Count > 0 || InValues.Count > 0);
            }
        }


        // helper methods
        public static OperatorType ToOperatorType(string op) {
            switch (op.ToLower()) {
                case "=":
                    return OperatorType.Equal;
                case ">":
                    return OperatorType.GreaterThan;
                case ">=":
                    return OperatorType.GreaterThanOrEquals;
                case "<":
                    return OperatorType.LessThan;
                case "<=":
                    return OperatorType.LessThanOrEquals;
                case "in":
                    return OperatorType.In;
                case "between":
                    return OperatorType.Between;
                case "like":
                    return OperatorType.Like;
                default:
                    return OperatorType.Unknown;
            }
        }

        public static string FromOperatorType(OperatorType opType) {
            switch (opType) {
                case OperatorType.Equal:
                    return "=";
                case OperatorType.GreaterThan:
                    return "gt";
                case OperatorType.GreaterThanOrEquals:
                    return "gte";
                case OperatorType.LessThan:
                    return "lt";
                case OperatorType.LessThanOrEquals:
                    return "lte";

                case OperatorType.In:
                case OperatorType.Between:
                default:
                    return opType.ToString();
            }

        }
    }
}
