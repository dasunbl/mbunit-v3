using System.IO;
using System.Text;

namespace MbUnit.Core.Services.Report
{
    /// <summary>
    /// A contextual report stream writer writes text messages to a report stream associated
    /// with the test execution context at the time it was written.
    /// </summary>
    public class ContextualReportStreamWriter : TextWriter
    {
        private string reportStreamName;

        /// <summary>
        /// Creates a text writer that writes to the specified report stream.
        /// </summary>
        /// <param name="reportStreamName">The report stream name</param>
        public ContextualReportStreamWriter(string reportStreamName)
        {
            this.reportStreamName = reportStreamName;
        }

        public override Encoding Encoding
        {
            get { return Encoding.Unicode; }
        }

        public override void Write(char value)
        {
            CurrentStream.Write(value);
        }

        public override void Write(string value)
        {
            CurrentStream.Write(value);
        }

        public override void Write(char[] buffer, int index, int count)
        {
            CurrentStream.Write(buffer, index, count);
        }

        private IReportStream CurrentStream
        {
            get { return ReportUtils.GetCurrentReport().Streams[reportStreamName]; }
        }
    }
}