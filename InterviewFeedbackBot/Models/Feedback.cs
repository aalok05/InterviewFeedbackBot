using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using System;
#pragma warning disable 649

namespace Microsoft.Bot.Sample.FormBot
{
    public enum Duration
    {
        [Describe("Too short")]
        TooShort,

        Adequate,

        [Describe("Too long")]
        TooLong
    };
    public enum InterviewerRating
    {
        [Describe("1")]
        One,

        [Describe("2")]
        Two,

        [Describe("3")]
        Three,

        [Describe("4")]
        Four,

        [Describe("5")]
        Five
    };
    public enum OverallExperience
    {
        Bad, Good, Excellent
    };

    [Serializable]
    public class Feedback
    {
        [Prompt("How long did you feel the interview was? {||}")]
        public Duration? Duration;

        [Describe("Interviewer Rating")]
        [Prompt("How would you rate the interviewer out of 5? {||}")]
        public InterviewerRating? InterviewerRating;

        [Describe("Overall Experience")]
        [Prompt("How was your overall experience with the interview? {||}")]
        public OverallExperience? OverallExperience;

        [Optional]
        [Prompt("Any other feedback?")]
        public string OtherFeedback;

        public static IForm<Feedback> BuildForm()
        {
            OnCompletionAsyncDelegate<Feedback> EndFeedbackProcess = async (context, state) =>
            {
                await context.PostAsync("Thanks for the feedback!");
            };

            return new FormBuilder<Feedback>()
                    .Message("Please provide feedback about today's interview.")
                    .OnCompletion(EndFeedbackProcess)
                    .Build();
        }
    };
}