using CliSharp.Attributes;

namespace VeraCryptSharp.Enums
{
    public enum Answer
    {
        [ParameterName("")]
        None,

        [ParameterName("y")]
        Yes,

        [ParameterName("n")]
        No
    }
}
