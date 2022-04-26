using System;

namespace DependencyInjection
{
    class FeedbackService : IFeedbackService
    {
        public void Feedback(string output)
        {
            Console.WriteLine(output);
        }
    }
}
