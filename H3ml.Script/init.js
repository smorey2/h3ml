/* imitate standarized console object */
var console = {
    log: string => {
        mscorlib.System.Console.WriteLine(string);
    },
    error: string => {
        mscorlib.System.Console.Error.WriteLine(string);
    }
};