using FileHelpers;

namespace MVD
{
    [DelimitedRecord(",")]
    public class Passp
    {
        public string? PASSP_SERIES { get; set; }
        public string? PASSP_NUMBER { get; set; }
    }
}