using NUnit.Framework;
using FluentValidation;
using System;
using FluentValidation.TestHelper;
using System.Linq.Expressions;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using Amica.Models;

namespace Validation.Tests
{
    [TestFixture]
    public abstract class BaseTestClass<TClass, TValidator> 
        where TClass : ObservableObject, new()
        where TValidator : IValidator<TClass>
    {
        protected TValidator validator;
        protected TClass challenge;

        [SetUp]
        public void Init()
        {
            validator = Activator.CreateInstance<TValidator>();
            challenge = Activator.CreateInstance<TClass>();
        }

        protected void AssertOptional<T>(Expression<Func<TClass, T>> outExpr )
        {
            var prop = GetProperty(outExpr);

            prop.SetValue(challenge, null);
            validator.ShouldNotHaveValidationErrorFor(outExpr, challenge);

            if (typeof(T) == typeof(string))
            {
                prop.SetValue(challenge, string.Empty);
                validator.ShouldNotHaveValidationErrorFor(outExpr, challenge);
            }

        }
        protected void AssertRequired<T>(Expression<Func<TClass, T>> outExpr, string expectedErrorCode=null)
        {
            var prop = GetProperty(outExpr);
            var type = typeof(T);

            if (expectedErrorCode == null)
            {
                expectedErrorCode = 
                    (type != typeof(string) && !IsNumericType(type)) ?  "notnull_error" :  "notempty_error";
            }

            prop.SetValue(challenge, null);
            var r = validator.Validate(challenge);
            validator.ShouldHaveValidationErrorFor(outExpr, challenge).WithErrorCode(expectedErrorCode);

            if (type == typeof(string))
            {
                prop.SetValue(challenge, string.Empty);
                validator.ShouldHaveValidationErrorFor(outExpr, challenge).WithErrorCode(expectedErrorCode);
            }

            if (IsNumericType(type))
            {
                prop.SetValue(challenge, 0);
                validator.ShouldHaveValidationErrorFor(outExpr, challenge).WithErrorCode(expectedErrorCode);
            }
        }
        protected void AssertMinMaxLength(Expression<Func<TClass, string>> outExpr, int min, int max, char filler='x', string expectedErrorCode="length_error")
        {
            var prop = GetProperty(outExpr);

            prop.SetValue(challenge, new string(filler, max+1));
            validator.ShouldHaveValidationErrorFor(outExpr, challenge).WithErrorCode(expectedErrorCode);
            prop.SetValue(challenge, new string(filler, min));
            validator.ShouldNotHaveValidationErrorFor(outExpr, challenge);
            prop.SetValue(challenge, new string(filler, max));
            validator.ShouldNotHaveValidationErrorFor(outExpr, challenge);
        }
        protected void AssertLength(Expression<Func<TClass, string>> outExpr, int length, char filler='x', string expectedErrorCode="exact_length_error")
        {
            var prop = GetProperty(outExpr);

            prop.SetValue(challenge, new string(filler, length+1));
            validator.ShouldHaveValidationErrorFor(outExpr, challenge).WithErrorCode(expectedErrorCode);
            prop.SetValue(challenge, new string(filler, length-1));
            validator.ShouldHaveValidationErrorFor(outExpr, challenge).WithErrorCode(expectedErrorCode);
            prop.SetValue(challenge, new string(filler, length));
            validator.ShouldNotHaveValidationErrorFor(outExpr, challenge);
        }
        protected void AssertValidEmail(Expression<Func<TClass, string>> outExpr)
        {
            var prop = GetProperty(outExpr);
            prop.SetValue(challenge, string.Empty);
			validator.ShouldHaveValidationErrorFor(outExpr, challenge);
            prop.SetValue(challenge, "fakeemail");
            validator.ShouldHaveValidationErrorFor(outExpr, challenge);
            prop.SetValue(challenge, "mail@mail");
            validator.ShouldHaveValidationErrorFor(outExpr, challenge);
            prop.SetValue(challenge, "@mail.it");
            validator.ShouldHaveValidationErrorFor(outExpr, challenge);
            prop.SetValue(challenge, @"test\@test@iana.org");
            validator.ShouldHaveValidationErrorFor(outExpr, challenge);
            prop.SetValue(challenge,  "mail@mail.it.com");
			validator.ShouldNotHaveValidationErrorFor(outExpr, challenge); 

            prop.SetValue(challenge,  "mail@mail.it");
			validator.ShouldNotHaveValidationErrorFor(outExpr, challenge);
            prop.SetValue(challenge,  null);
            validator.ShouldNotHaveValidationErrorFor(outExpr, challenge);
        }
        protected void AssertValidVatIdentificationNumber(Expression<Func<TClass, string>> outExpr)
        {
            var prop = GetProperty(outExpr);

            var invalid = new string[] {string.Empty, "A", "01180680399", "UK01180680397", "IT01180680399"};
			foreach(var idCode in invalid)
            {
                prop.SetValue(challenge, idCode);
				validator.ShouldHaveValidationErrorFor(outExpr, idCode);
            }

            var valid = new string[] {null, "01180680397", "IT01180680397", "02182030391", "IT02182030391", "92078790398"};
            foreach (var idCode in valid)
            {
                prop.SetValue(challenge, idCode);
				validator.ShouldNotHaveValidationErrorFor(outExpr, value:idCode);
            }
        }
        protected void AssertValidTaxIdentificationNumber(Expression<Func<TClass, string>> outExpr)
        {
            var prop = GetProperty(outExpr);

            var invalid = new string[]
            {
                string.Empty,
				// last char is wrong
                "RCCNCL70M27B519Z",
				// too short
				"8012345678", "9012345678",
				// too long
				"801234567890", "901234567890",
				// not valid
				"80123456789", "90123456789"
            };
            foreach (var idCode in invalid)
            {
                prop.SetValue(challenge, idCode);
                validator.ShouldHaveValidationErrorFor(outExpr, value:idCode);
            }


            var valid = new string[] {
                null,
                "RCCNCL70M27B519E", "grdsfn66d17h199k",
                "92078790398", "95052810132", "94078890541", "90029830669",
                "81004300067", "80064390372", "80028050583", "80007770102", "80003350891"
            };
            foreach (var idCode in valid)
                validator.ShouldNotHaveValidationErrorFor(outExpr, value: idCode);
        }
        protected void AssertCollectionCanBeEmpty<T>(Expression<Func<TClass, List<T>>> outExpr)
        {
            var prop = GetProperty(outExpr);

            var r = validator.Validate(challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == prop.Name));
        }
        public void AssertCollectionCannotBeEmpty<T>(Expression<Func<TClass, List<T>>> outExpr)
        {
            var prop = GetProperty(outExpr);
            
            var r = validator.Validate(challenge);
            Assert.AreEqual("notempty_error", r.Errors.FirstOrDefault(x => x.PropertyName == prop.Name).ErrorCode);

        }
        private PropertyInfo GetProperty<T>(Expression<Func<TClass, T>> outExpr)
        {
            var expr = (MemberExpression)outExpr.Body;
            return (PropertyInfo)expr.Member;
        }
        private static HashSet<Type> NumericTypes = new HashSet<Type>
        {
            typeof(int),
            typeof(uint),
            typeof(double),
            typeof(decimal),
            typeof(long),
        };
        private static bool IsNumericType(Type type)
        {
            return NumericTypes.Contains(type) || NumericTypes.Contains(Nullable.GetUnderlyingType(type));
        }
    }
}
