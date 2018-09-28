﻿/* 
 * Copyright (c) 2015, Firely (info@fire.ly) and contributors
 * See the file CONTRIBUTORS for details.
 * 
 * This file is licensed under the BSD 3-Clause license
 * available at https://raw.githubusercontent.com/ewoutkramer/fhir-net-api/master/LICENSE
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl7.FhirPath.Expressions
{
    public abstract class ExpressionVisitor<T>
    {
        //public void Visit(Expression expression)
        //{
        //    if (expression is ConstantExpression)
        //        VisitConstant((ConstantExpression)expression);
        //    else if (expression is FunctionCallExpression)
        //        VisitFunctionCall((FunctionCallExpression)expression);
        //    else if (expression is LambdaExpression)
        //        VisitLambda((LambdaExpression)expression);
        //    else if (expression is NewNodeListInitExpression)
        //        VisitNewNodeListInit((NewNodeListInitExpression)expression);
        //    else if (expression is VariableRefExpression)
        //        VisitVariableRef((VariableRefExpression)expression);
        //}

        public abstract T VisitConstant(ConstantExpression expression);

        public abstract T VisitFunctionCall(FunctionCallExpression expression);

        //public abstract T VisitLambda(LambdaExpression expression);

        public abstract T VisitNewNodeListInit(NewNodeListInitExpression expression);

        public abstract T VisitVariableRef(VariableRefExpression expression);

        //public abstract T VisitTypeBinaryExpression(TypeBinaryExpression expression);
    }
}
