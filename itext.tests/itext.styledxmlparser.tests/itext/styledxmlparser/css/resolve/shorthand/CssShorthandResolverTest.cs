/*
This file is part of the iText (R) project.
Copyright (c) 1998-2018 iText Group NV
Authors: iText Software.

This program is free software; you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License version 3
as published by the Free Software Foundation with the addition of the
following permission added to Section 15 as permitted in Section 7(a):
FOR ANY PART OF THE COVERED WORK IN WHICH THE COPYRIGHT IS OWNED BY
ITEXT GROUP. ITEXT GROUP DISCLAIMS THE WARRANTY OF NON INFRINGEMENT
OF THIRD PARTY RIGHTS

This program is distributed in the hope that it will be useful, but
WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
or FITNESS FOR A PARTICULAR PURPOSE.
See the GNU Affero General Public License for more details.
You should have received a copy of the GNU Affero General Public License
along with this program; if not, see http://www.gnu.org/licenses or write to
the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor,
Boston, MA, 02110-1301 USA, or download the license from the following URL:
http://itextpdf.com/terms-of-use/

The interactive user interfaces in modified source and object code versions
of this program must display Appropriate Legal Notices, as required under
Section 5 of the GNU Affero General Public License.

In accordance with Section 7(b) of the GNU Affero General Public License,
a covered work must retain the producer line in every PDF that is created
or manipulated using iText.

You can be released from the requirements of the license by purchasing
a commercial license. Buying such a license is mandatory as soon as you
develop commercial activities involving the iText software without
disclosing the source code of your own applications.
These activities include: offering paid services to customers as an ASP,
serving PDFs on the fly in a web application, shipping iText with a closed
source product.

For more information, please contact iText Software Corp. at this
address: sales@itextpdf.com
*/
using System;
using System.Collections.Generic;
using System.Text;
using iText.IO.Util;
using iText.StyledXmlParser.Css;
using iText.Test;

namespace iText.StyledXmlParser.Css.Resolve.Shorthand {
    public class CssShorthandResolverTest : ExtendedITextTest {
        [NUnit.Framework.Test]
        public virtual void FontTest01() {
            String shorthandExpression = "italic normal bold 12px/30px Georgia, serif";
            ICollection<String> expectedResolvedProperties = new HashSet<String>(JavaUtil.ArraysAsList("font-style: italic"
                , "font-variant: initial", "font-weight: bold", "font-size: 12px", "line-height: 30px", "font-family: georgia,serif"
                ));
            IShorthandResolver resolver = ShorthandResolverFactory.GetShorthandResolver(CommonCssConstants.FONT);
            NUnit.Framework.Assert.IsNotNull(resolver);
            IList<CssDeclaration> resolvedShorthandProps = resolver.ResolveShorthand(shorthandExpression);
            CompareResolvedProps(resolvedShorthandProps, expectedResolvedProperties);
        }

        [NUnit.Framework.Test]
        public virtual void FontTest02() {
            String shorthandExpression = "bold Georgia, serif";
            ICollection<String> expectedResolvedProperties = new HashSet<String>(JavaUtil.ArraysAsList("font-style: initial"
                , "font-variant: initial", "font-weight: bold", "font-size: initial", "line-height: initial", "font-family: georgia,serif"
                ));
            IShorthandResolver resolver = ShorthandResolverFactory.GetShorthandResolver(CommonCssConstants.FONT);
            NUnit.Framework.Assert.IsNotNull(resolver);
            IList<CssDeclaration> resolvedShorthandProps = resolver.ResolveShorthand(shorthandExpression);
            CompareResolvedProps(resolvedShorthandProps, expectedResolvedProperties);
        }

        [NUnit.Framework.Test]
        public virtual void FontTest03() {
            String shorthandExpression = "inherit";
            ICollection<String> expectedResolvedProperties = new HashSet<String>(JavaUtil.ArraysAsList("font-style: inherit"
                , "font-variant: inherit", "font-weight: inherit", "font-size: inherit", "line-height: inherit", "font-family: inherit"
                ));
            IShorthandResolver resolver = ShorthandResolverFactory.GetShorthandResolver(CommonCssConstants.FONT);
            NUnit.Framework.Assert.IsNotNull(resolver);
            IList<CssDeclaration> resolvedShorthandProps = resolver.ResolveShorthand(shorthandExpression);
            CompareResolvedProps(resolvedShorthandProps, expectedResolvedProperties);
        }

        [NUnit.Framework.Test]
        public virtual void FontTest04() {
            String shorthandExpression = "bold Georgia, serif, \"Times New Roman\"";
            ICollection<String> expectedResolvedProperties = new HashSet<String>(JavaUtil.ArraysAsList("font-style: initial"
                , "font-variant: initial", "font-weight: bold", "font-size: initial", "line-height: initial", "font-family: georgia,serif,\"Times New Roman\""
                ));
            IShorthandResolver resolver = ShorthandResolverFactory.GetShorthandResolver(CommonCssConstants.FONT);
            NUnit.Framework.Assert.IsNotNull(resolver);
            IList<CssDeclaration> resolvedShorthandProps = resolver.ResolveShorthand(shorthandExpression);
            CompareResolvedProps(resolvedShorthandProps, expectedResolvedProperties);
        }

        [NUnit.Framework.Test]
        public virtual void FontTest05() {
            String shorthandExpression = "italic normal bold 12px/30px Georgia, \"Times New Roman\", serif";
            ICollection<String> expectedResolvedProperties = new HashSet<String>(JavaUtil.ArraysAsList("font-style: italic"
                , "font-variant: initial", "font-weight: bold", "font-size: 12px", "line-height: 30px", "font-family: georgia,\"Times New Roman\",serif"
                ));
            IShorthandResolver resolver = ShorthandResolverFactory.GetShorthandResolver(CommonCssConstants.FONT);
            NUnit.Framework.Assert.IsNotNull(resolver);
            IList<CssDeclaration> resolvedShorthandProps = resolver.ResolveShorthand(shorthandExpression);
            CompareResolvedProps(resolvedShorthandProps, expectedResolvedProperties);
        }

        [NUnit.Framework.Test]
        public virtual void FontTest06() {
            String shorthandExpression = "italic normal bold 12px/30px Georgia    ,   \"Times New Roman\"   ,    serif";
            ICollection<String> expectedResolvedProperties = new HashSet<String>(JavaUtil.ArraysAsList("font-style: italic"
                , "font-variant: initial", "font-weight: bold", "font-size: 12px", "line-height: 30px", "font-family: georgia,\"Times New Roman\",serif"
                ));
            IShorthandResolver resolver = ShorthandResolverFactory.GetShorthandResolver(CommonCssConstants.FONT);
            NUnit.Framework.Assert.IsNotNull(resolver);
            IList<CssDeclaration> resolvedShorthandProps = resolver.ResolveShorthand(shorthandExpression);
            CompareResolvedProps(resolvedShorthandProps, expectedResolvedProperties);
        }

        [NUnit.Framework.Test]
        public virtual void FontTest07() {
            String shorthandExpression = "italic normal bold 12px/30px Georgia    ,   \"Times New Roman\"   ";
            ICollection<String> expectedResolvedProperties = new HashSet<String>(JavaUtil.ArraysAsList("font-style: italic"
                , "font-variant: initial", "font-weight: bold", "font-size: 12px", "line-height: 30px", "font-family: georgia,\"Times New Roman\""
                ));
            IShorthandResolver resolver = ShorthandResolverFactory.GetShorthandResolver(CommonCssConstants.FONT);
            NUnit.Framework.Assert.IsNotNull(resolver);
            IList<CssDeclaration> resolvedShorthandProps = resolver.ResolveShorthand(shorthandExpression);
            CompareResolvedProps(resolvedShorthandProps, expectedResolvedProperties);
        }

        [NUnit.Framework.Test]
        public virtual void FontTest08() {
            String shorthandExpression = "Georgia,'Times New Roman'";
            ICollection<String> expectedResolvedProperties = new HashSet<String>(JavaUtil.ArraysAsList("font-style: initial"
                , "font-variant: initial", "font-weight: initial", "font-size: initial", "line-height: initial", "font-family: georgia,'Times New Roman'"
                ));
            IShorthandResolver resolver = ShorthandResolverFactory.GetShorthandResolver(CommonCssConstants.FONT);
            NUnit.Framework.Assert.IsNotNull(resolver);
            IList<CssDeclaration> resolvedShorthandProps = resolver.ResolveShorthand(shorthandExpression);
            CompareResolvedProps(resolvedShorthandProps, expectedResolvedProperties);
        }

        [NUnit.Framework.Test]
        public virtual void FontTest09() {
            String shorthandExpression = "Georgia  ,   'Times New Roman', serif";
            ICollection<String> expectedResolvedProperties = new HashSet<String>(JavaUtil.ArraysAsList("font-style: initial"
                , "font-variant: initial", "font-weight: initial", "font-size: initial", "line-height: initial", "font-family: georgia,'Times New Roman',serif"
                ));
            IShorthandResolver resolver = ShorthandResolverFactory.GetShorthandResolver(CommonCssConstants.FONT);
            NUnit.Framework.Assert.IsNotNull(resolver);
            IList<CssDeclaration> resolvedShorthandProps = resolver.ResolveShorthand(shorthandExpression);
            CompareResolvedProps(resolvedShorthandProps, expectedResolvedProperties);
        }

        private void CompareResolvedProps(IList<CssDeclaration> actual, ICollection<String> expected) {
            ICollection<String> actualSet = new HashSet<String>();
            foreach (CssDeclaration cssDecl in actual) {
                actualSet.Add(cssDecl.ToString());
            }
            bool areDifferent = false;
            StringBuilder sb = new StringBuilder("Resolved styles are different from expected!");
            ICollection<String> expCopy = new SortedSet<String>(expected);
            ICollection<String> actCopy = new SortedSet<String>(actualSet);
            expCopy.RemoveAll(actualSet);
            actCopy.RemoveAll(expected);
            if (!expCopy.IsEmpty()) {
                areDifferent = true;
                sb.Append("\nExpected but not found properties:\n");
                foreach (String expProp in expCopy) {
                    sb.Append(expProp).Append('\n');
                }
            }
            if (!actCopy.IsEmpty()) {
                areDifferent = true;
                sb.Append("\nNot expected but found properties:\n");
                foreach (String actProp in actCopy) {
                    sb.Append(actProp).Append('\n');
                }
            }
            if (areDifferent) {
                NUnit.Framework.Assert.Fail(sb.ToString());
            }
        }
    }
}
