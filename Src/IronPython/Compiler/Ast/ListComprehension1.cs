// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information.

using MSAst = System.Linq.Expressions;

using System;

namespace IronPython.Compiler.Ast {
    using Ast = MSAst.Expression;
    public class ListComprehension1 : Expression {

        public ListComprehension1(FunctionDefinition function, Expression elt) {
            Function = function;
            Elt = elt;
        }
        public override MSAst.Expression Reduce() {
            return Ast.Call(AstMethods.Invoke0, Function.MakeFunctionExpression());
        }

        public FunctionDefinition Function { get; }
        public Expression Elt { get; }

        public override string NodeName => "list comprehension";

        public override void Walk(PythonWalker walker) {
            if (walker.Walk(this)) {
                Function.Walk(walker);
            }
            walker.PostWalk(this);
        }
    }
}