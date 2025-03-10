﻿namespace GitUI.UserControls
{
    public class RevisionFilter
    {
        // TODO: consider using a bit vector or an enum

        public RevisionFilter(string text, bool byCommit, bool byCommitter, bool byAuthor, bool byDiffContent)
        {
            Text = text;
            FilterByCommit = byCommit;
            FilterByCommitter = byCommitter;
            FilterByAuthor = byAuthor;
            FilterByDiffContent = byDiffContent;
        }

        public string Text { get; }
        public bool FilterByCommit { get; }
        public bool FilterByCommitter { get; }
        public bool FilterByAuthor { get; }
        public bool FilterByDiffContent { get; }
    }
}
