﻿// Copyright (c) Tunnel Vision Laboratories, LLC. All Rights Reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace StyleCop.Analyzers.Test.CSharp7.DocumentationRules
{
    using System.Threading.Tasks;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using StyleCop.Analyzers.Test.DocumentationRules;
    using Xunit;

    public class SA1600CSharp7UnitTests : SA1600UnitTests
    {
        private string currentTestSettings;

        [Fact]
        public async Task TestPrivateProtectedDelegateWithoutDocumentationAsync()
        {
            await this.TestNestedDelegateDeclarationDocumentationAsync("private protected", true, false).ConfigureAwait(false);
        }

        [Fact]
        public async Task TestPrivateProtectedDelegateWithDocumentationAsync()
        {
            await this.TestNestedDelegateDeclarationDocumentationAsync("private protected", false, true).ConfigureAwait(false);
        }

        [Fact]
        public async Task TestPrivateProtectedMethodWithoutDocumentationAsync()
        {
            await this.TestMethodDeclarationDocumentationAsync("private protected", false, true, false).ConfigureAwait(false);
        }

        [Fact]
        public async Task TestPrivateProtectedMethodWithDocumentationAsync()
        {
            await this.TestMethodDeclarationDocumentationAsync("private protected", false, false, true).ConfigureAwait(false);
        }

        [Fact]
        public async Task TestPrivateProtectedConstructorWithoutDocumentationAsync()
        {
            await this.TestConstructorDeclarationDocumentationAsync("private protected", true, false).ConfigureAwait(false);
        }

        [Fact]
        public async Task TestPrivateProtectedConstructorWithDocumentationAsync()
        {
            await this.TestConstructorDeclarationDocumentationAsync("private protected", false, true).ConfigureAwait(false);
        }

        [Fact]
        public async Task TestPrivateProtectedFieldWithoutDocumentationAsync()
        {
            await this.TestFieldDeclarationDocumentationAsync("private protected", true, false).ConfigureAwait(false);

            // Re-test with the 'documentPrivateElements' setting enabled (doesn't impact fields)
            this.currentTestSettings = @"
{
  ""settings"": {
    ""documentationRules"": {
      ""documentPrivateElements"": true
    }
  }
}
";

            await this.TestFieldDeclarationDocumentationAsync("private protected", true, false).ConfigureAwait(false);

            // Re-test with the 'documentInternalElements' setting disabled (does impact fields)
            this.currentTestSettings = @"
{
  ""settings"": {
    ""documentationRules"": {
      ""documentInternalElements"": false
    }
  }
}
";

            await this.TestFieldDeclarationDocumentationAsync("private protected", false, false).ConfigureAwait(false);

            // Re-test with the 'documentPrivateFields' setting enabled (does impact fields)
            this.currentTestSettings = @"
{
  ""settings"": {
    ""documentationRules"": {
      ""documentPrivateFields"": true
    }
  }
}
";

            await this.TestFieldDeclarationDocumentationAsync("private protected", true, false).ConfigureAwait(false);
        }

        [Fact]
        public async Task TestPrivateProtectedFieldWithDocumentationAsync()
        {
            await this.TestFieldDeclarationDocumentationAsync("private protected", false, true).ConfigureAwait(false);

            // Re-test with the 'documentPrivateElements' setting enabled (doesn't impact fields)
            this.currentTestSettings = @"
{
  ""settings"": {
    ""documentationRules"": {
      ""documentPrivateElements"": true
    }
  }
}
";

            await this.TestFieldDeclarationDocumentationAsync("private protected", false, true).ConfigureAwait(false);

            // Re-test with the 'documentInternalElements' setting disabled (does impact fields)
            this.currentTestSettings = @"
{
  ""settings"": {
    ""documentationRules"": {
      ""documentInternalElements"": false
    }
  }
}
";

            await this.TestFieldDeclarationDocumentationAsync("private protected", false, true).ConfigureAwait(false);

            // Re-test with the 'documentPrivateFields' setting enabled (does impact fields)
            this.currentTestSettings = @"
{
  ""settings"": {
    ""documentationRules"": {
      ""documentPrivateFields"": true
    }
  }
}
";

            await this.TestFieldDeclarationDocumentationAsync("private protected", false, true).ConfigureAwait(false);
        }

        [Fact]
        public async Task TestPrivateProtectedPropertyWithoutDocumentationAsync()
        {
            await this.TestPropertyDeclarationDocumentationAsync("private protected", false, true, false).ConfigureAwait(false);
        }

        [Fact]
        public async Task TestPrivateProtectedPropertyWithDocumentationAsync()
        {
            await this.TestPropertyDeclarationDocumentationAsync("private protected", false, false, true).ConfigureAwait(false);
        }

        [Fact]
        public async Task TestPrivateProtectedIndexerWithoutDocumentationAsync()
        {
            await this.TestIndexerDeclarationDocumentationAsync("private protected", false, true, false).ConfigureAwait(false);
        }

        [Fact]
        public async Task TestPrivateProtectedIndexerWithDocumentationAsync()
        {
            await this.TestIndexerDeclarationDocumentationAsync("private protected", false, false, true).ConfigureAwait(false);
        }

        [Fact]
        public async Task TestPrivateProtectedEventWithoutDocumentationAsync()
        {
            await this.TestEventDeclarationDocumentationAsync("private protected", false, true, false).ConfigureAwait(false);
        }

        [Fact]
        public async Task TestPrivateProtectedEventWithDocumentationAsync()
        {
            await this.TestEventDeclarationDocumentationAsync("private protected", false, false, true).ConfigureAwait(false);
        }

        [Fact]
        public async Task TestPrivateProtectedEventFieldWithoutDocumentationAsync()
        {
            await this.TestEventFieldDeclarationDocumentationAsync("private protected", true, false).ConfigureAwait(false);
        }

        [Fact]
        public async Task TestPrivateProtectedEventFieldWithDocumentationAsync()
        {
            await this.TestEventFieldDeclarationDocumentationAsync("private protected", false, true).ConfigureAwait(false);
        }

        protected override string GetSettings()
        {
            return this.currentTestSettings ?? base.GetSettings();
        }

        protected override Project CreateProjectImpl(string[] sources, string language, string[] filenames)
        {
            var project = base.CreateProjectImpl(sources, language, filenames);
            var parseOptions = (CSharpParseOptions)project.ParseOptions;
            return project.WithParseOptions(parseOptions.WithLanguageVersion(LanguageVersion.CSharp7_2));
        }

        protected override async Task TestTypeWithoutDocumentationAsync(string type, bool isInterface)
        {
            await base.TestTypeWithoutDocumentationAsync(type, isInterface).ConfigureAwait(false);

            await this.TestNestedTypeDeclarationDocumentationAsync(type, "private protected", true, false).ConfigureAwait(false);
        }

        protected override async Task TestTypeWithDocumentationAsync(string type)
        {
            await base.TestTypeWithDocumentationAsync(type).ConfigureAwait(false);

            await this.TestNestedTypeDeclarationDocumentationAsync(type, "private protected", false, true).ConfigureAwait(false);
        }
    }
}
