using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agathas.Storefront.Infrastructure.Querying;
using System.Linq.Expressions;

namespace Agathas.Storefront.UnitTest.Infrastructure.Querying
{
    [TestClass]
    public class PropertyNameHelperTest
    {
        const string strExpressTest = "非项目内Express测试"; 

        [TestMethod]
        public void ResolvePropertyNameTest()
        {
            string propertyName = PropertyNameHelper.ResolvePropertyName<AnimalNormalClass>(a => a.species);
            Assert.AreEqual("species", propertyName);
        }



        [TestCategory(strExpressTest)]
        [TestMethod]
        public void CreatFieldExpresssion_NotByConstant()
        {
            Expression<Func<AnimalNormalClass, object>> expr = a => a.species;
            var memberExpression = expr.Body as MemberExpression;

            //Assert.AreEqual(expr.GetType(), typeof(Expression));  //这个测试通不过
            //Assert.AreEqual(memberExpression.GetType(), typeof(MemberExpression));  //这个测试也通不过
            Assert.AreEqual("a.species", memberExpression.ToString());
        }


        [TestCategory(strExpressTest)]
        [TestMethod]
        public void CreateFieldExpression_ByConstant_InnerClass()
        {
            AnimalInnerClass horse = new AnimalInnerClass();

            System.Linq.Expressions.MemberExpression memberExpression =
                System.Linq.Expressions.Expression.Field(
                    System.Linq.Expressions.Expression.Constant(horse),
                    "species");

            Assert.AreEqual(
                "value(Agathas.Storefront.UnitTest.Infrastructure.Querying.PropertyNameHelperTest+AnimalInnerClass).species"
                ,memberExpression.ToString());
        }
        class AnimalInnerClass
        {
            public string species = null;
        }


        [TestCategory(strExpressTest)]
        [TestMethod]
        public void CreateFieldExpression_ByConstant_NormalClass()
        {
            AnimalNormalClass horse = new AnimalNormalClass();

            System.Linq.Expressions.MemberExpression memberExpression =
                System.Linq.Expressions.Expression.Field(
                    System.Linq.Expressions.Expression.Constant(horse),
                    "species");

            Assert.AreEqual(
                "value(Agathas.Storefront.UnitTest.Infrastructure.Querying.AnimalNormalClass).species"
                ,memberExpression.ToString());
        }
    }

    class AnimalNormalClass
    {
        public string species = null;
    }
}
