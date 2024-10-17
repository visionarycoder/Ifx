using System;
using System.Collections.Generic;
using System.Text;

namespace Encoder;

internal enum ConversionDirection
    {
        EbcdicToAscii,
        AsciiToEbcdic
    }

    internal class ConversionMap
    {
        public byte Ebcdic { get; set; }
        public char Ascii { get; set; }
        public string Meaning { get; set; }
        public ConversionDirection Direction { get; }
    }

    public class Converter
    {
        private static readonly Dictionary<byte, char> EBCDICToASCIIDict = new Dictionary<byte, char>
        {
            // Add EBCDIC to ASCII mappings here
            { 0x81, 'a' }, // Example mapping
            { 0x82, 'b' }, // Example mapping
            // Add more mappings
        };

        private static readonly Dictionary<char, byte> ASCIIToEBCDICDict = new Dictionary<char, byte>
        {
            // Add ASCII to EBCDIC mappings here
            { 'a', 0x81 }, // Example mapping
            { 'b', 0x82 }, // Example mapping
            // Add more mappings
        };

        public static string EBCDICToASCII(byte[] ebcdicBytes)
        {
            StringBuilder asciiString = new StringBuilder();
            foreach (byte ebcdicByte in ebcdicBytes)
            {
                if (EBCDICToASCIIDict.TryGetValue(ebcdicByte, out char asciiChar))
                {
                    asciiString.Append(asciiChar);
                }
                else
                {
                    asciiString.Append('?'); // Unknown character
                }
            }
            return asciiString.ToString();
        }

        public static byte[] ASCIIToEBCDIC(string asciiString)
        {
            var bytes = new List<byte>();
            foreach (char asciiChar in asciiString)
            {
                if (ASCIIToEBCDICDict.TryGetValue(asciiChar, out byte ebcdicByte))
                {
                    bytes.Add(ebcdicByte);
                }
                else
                {
                    bytes.Add(0x3F); // Unknown character
                }
            }
            return bytes.ToArray();
        }
    }


 