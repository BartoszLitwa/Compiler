﻿using Compiler.Syntax;

namespace Compiler
{
    public class Lexer
    {
        private readonly string _text;
        private int _position;
        private List<String> _diagnostic = new();

        public Lexer(string text)
        {
            _text = text;
        }

        public IEnumerable<string> Diagnostics => _diagnostic;

        private char Current
        {
            get
            {
                if(_position >= _text.Length)
                    return '\0';
                return _text[_position];
            }
        }

        private void Next() => _position++;

        public SyntaxToken NextToken()
        {
            if(_position >= _text.Length)
                return new SyntaxToken(SyntaxKind.EndOfFileToken, _position, "\0", null);

            if(char.IsDigit(Current))
            {
                var start = _position;
                while(char.IsDigit(Current))
                    Next();

                var length = _position - start;
                var text = _text.Substring(start, length);
                if(!int.TryParse(text, out var value))
                {
                    _diagnostic.Add($"The number {_text} isn't valid Int32");
                }

                return new SyntaxToken(SyntaxKind.NumberToken, start, text, value);
            }

            if (char.IsWhiteSpace(Current))
            {
                var start = _position;
                while (char.IsWhiteSpace(Current))
                    Next();

                var length = _position - start;
                var text = _text.Substring(start, length);

                return new SyntaxToken(SyntaxKind.WhitespaceToken, start, text, null);
            }

            return Current switch
            {
                '+' => new SyntaxToken(SyntaxKind.PlusToken, _position++, "+", null),
                '-' => new SyntaxToken(SyntaxKind.MinusToken, _position++, "-", null),
                '*' => new SyntaxToken(SyntaxKind.StarToken, _position++, "*", null),
                '/' => new SyntaxToken(SyntaxKind.SlashToken, _position++, "/", null),
                '(' => new SyntaxToken(SyntaxKind.OpenParenthesisToken, _position++, "(", null),
                ')' => new SyntaxToken(SyntaxKind.CloseParenthesisToken, _position++, ")", null),
                _ => ReturnBadToken()
            };
        }

        private SyntaxToken ReturnBadToken()
        {
            _diagnostic.Add($"ERROR: bad character input: '{Current}'");
            return new SyntaxToken(SyntaxKind.BadToken, _position++, _text.Substring(_position - 1, 1), null);
        }
    }
}
