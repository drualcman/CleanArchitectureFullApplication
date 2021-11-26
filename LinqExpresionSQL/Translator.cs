using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace LinqExpresionSQL
{
    public class Translator : ExpressionVisitor
    {
        StringBuilder Builder;
        object ExpressionContainer;
        public string Translate(object expressionContainer, Expression expression)
        {
            Builder = new StringBuilder();
            ExpressionContainer = expressionContainer;

            Visit(expression);
            return Builder.ToString();
        }

        protected override Expression VisitBinary(BinaryExpression binaryExpression)
        {
            Builder.Append("(");
            Visit(binaryExpression.Left);
            switch (binaryExpression.NodeType)
            {
                case ExpressionType.Equal:
                    Builder.Append(" = ");
                    break;
                case ExpressionType.NotEqual:
                    Builder.Append(" <> ");
                    break;
                case ExpressionType.GreaterThan:
                    Builder.Append(" > ");
                    break;
                case ExpressionType.GreaterThanOrEqual:
                    Builder.Append(" >= ");
                    break;
                case ExpressionType.LessThan:
                    Builder.Append(" < ");
                    break;
                case ExpressionType.LessThanOrEqual:
                    Builder.Append(" <= ");
                    break;
                default:
                    throw new NotSupportedException(
                        string.Format(
                            "The binary operator '{0}' is not supported",
                            binaryExpression.NodeType));

            }
            Visit(binaryExpression.Right);
            Builder.Append(")");
            return binaryExpression;
        }

        protected override Expression VisitConstant(ConstantExpression constantExpression)
        {
            if (constantExpression.Value == null)
            {
                Builder.Append("NULL");
            }
            else
            {
                switch (Type.GetTypeCode(constantExpression.Value.GetType()))
                {
                    case TypeCode.DateTime:
                        Builder.Append("'");
                        Builder.Append(((DateTime)constantExpression.Value).ToString("o"));
                        Builder.Append("'");
                        break;
                    default:
                        Builder.Append(constantExpression.Value);
                        break;
                }
            }
            return constantExpression;
        }



        #region Helpers
        bool IsParameterMember(MemberExpression memberExpression)
        {
            bool Result = false;
            if (memberExpression.Expression != null &&
                memberExpression.Expression.NodeType == ExpressionType.Parameter)
            {
                Builder.Append(memberExpression.Member.Name);
                Result = true;
            };
            return Result;
        }

        bool IsExpressionContainerFieldMember(MemberExpression memberExpression)
        {
            bool Result = false;
            var Field = ExpressionContainer.GetType().GetField(memberExpression.Member.Name,
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (Field != null)
            {
                var FieldValue = Field.GetValue(ExpressionContainer);
                ConstantExpression c = Expression.Constant(FieldValue);
                Visit(c);
                Result = true;
            }
            return Result;
        }

        bool IsDatePropertyMember(MemberExpression memberExpression)
        {
            bool Result = false;

            if (memberExpression.Member.DeclaringType == typeof(DateTime) &&
                (memberExpression.Member.Name == "Date"))
            {
                Builder.Append("Convert(date,");
                Visit(memberExpression.Expression);
                Builder.Append(")");
                Result = true;
            }

            return Result;
        }
        #endregion

        protected override Expression VisitMember(MemberExpression memberExpression)
        {
            if (!IsParameterMember(memberExpression) &&
                !IsExpressionContainerFieldMember(memberExpression) &&
                !IsDatePropertyMember(memberExpression))
            {
                throw new NotSupportedException(
                    string.Format("The member '{0}' is not supported",
                    memberExpression.Member.Name));
            }
            return memberExpression;
        }

    }

}
