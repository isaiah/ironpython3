// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information.

using MSAst = System.Linq.Expressions;

using System;

namespace IronPython.Compiler.Ast {
    using Ast = MSAst.Expression;
    public class SelfExAnonymousFunc : Expression {

        public SelfExAnonymousFunc(FunctionDefinition function) {
            Function = function;
        }
        public override MSAst.Expression Reduce() {
            return Ast.Call(AstMethods.Invoke0, Function.MakeFunctionExpression());
        }

        public FunctionDefinition Function { get; }

        public override string NodeName => "comprehension scope";

        public override void Walk(PythonWalker walker) {
            if (walker.Walk(this)) {
                Function.Walk(walker);
            }
            walker.PostWalk(this);
        }
    }
}
