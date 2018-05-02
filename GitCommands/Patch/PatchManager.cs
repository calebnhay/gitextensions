        private List<Patch> _patches = new List<Patch>();

        public List<Patch> Patches
        {
            get { return _patches; }
            set { _patches = value; }
        }

            string header;

            ChunkList selectedChunks = ChunkList.GetSelectedChunks(text, selectionPosition, selectionLength, staged, out header);
            //git apply has problem with dealing with autocrlf
            //I noticed that patch applies when '\r' chars are removed from patch if autocrlf is set to true
        public static byte[] GetSelectedLinesAsPatch(GitModule module, string text, int selectionPosition, int selectionLength, bool staged, Encoding fileContentEncoding, bool isNewFile)

            string header;

            ChunkList selectedChunks = ChunkList.GetSelectedChunks(text, selectionPosition, selectionLength, staged, out header);
            //if file is new, --- /dev/null has to be replaced by --- a/fileName
            else
                return GetPatchBytes(header, body, fileContentEncoding);
            string[] headerLines = header.Split(new string[] {"\n"}, StringSplitOptions.RemoveEmptyEntries);
        public static byte[] GetSelectedLinesAsNewPatch(GitModule module, string newFileName, string text, int selectionPosition, int selectionLength, Encoding fileContentEncoding, bool reset, byte[] FilePreabmle)
            string fileMode = "100000";//given fake mode to satisfy patch format, git will override this
            ChunkList selectedChunks = ChunkList.FromNewFile(module, text, selectionPosition, selectionLength, reset, FilePreabmle, fileContentEncoding);
            //git apply has problem with dealing with autocrlf
            //I noticed that patch applies when '\r' chars are removed from patch if autocrlf is set to true
            var s = new System.Text.StringBuilder();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(input);
        //TODO encoding for each file in patch should be obtained separately from .gitattributes
            _patches = patchProcessor.CreatePatchesFromString(text).ToList();
            foreach (Patch patchApply in _patches)
        public string Text { get; set; }
            var c = new PatchLine();
            c.Text = Text;
            c.Selected = Selected;
            return c;
        public List<PatchLine> PreContext = new List<PatchLine>();
        public List<PatchLine> RemovedLines = new List<PatchLine>();
        public List<PatchLine> AddedLines = new List<PatchLine>();
        public List<PatchLine> PostContext = new List<PatchLine>();
        public string WasNoNewLineAtTheEnd = null;
        public string IsNoNewLineAtTheEnd = null;



            //stage no new line at the end only if last +- line is selected
        //patch base is changed file
        private int StartLine;
        private List<SubChunk> SubChunks = new List<SubChunk>();
        private SubChunk _CurrentSubChunk = null;
                if (_CurrentSubChunk == null)
                    _CurrentSubChunk = new SubChunk();
                    SubChunks.Add(_CurrentSubChunk);
                return _CurrentSubChunk;
            //if postContext is not empty @line comes from next SubChunk
                _CurrentSubChunk = null;//start new SubChunk
            return int.TryParse(header, out StartLine);
                    PatchLine patchLine = new PatchLine()
                        Text = line
                    };
                    //do not refactor, there are no break points condition in VS Experss
                    if (currentPos <= selectionPosition + selectionLength && currentPos + line.Length >= selectionPosition)

        public static Chunk FromNewFile(GitModule module, string fileText, int selectionPosition, int selectionLength, bool reset, byte[] FilePreabmle, Encoding fileContentEncoding)
            Chunk result = new Chunk();
            result.StartLine = 0;
            string[] lines = fileText.Split(new string[] { eol }, StringSplitOptions.None);
                string preamble = (i == 0 ? new string(fileContentEncoding.GetChars(FilePreabmle)) : string.Empty);
                PatchLine patchLine = new PatchLine()
                    Text = (reset ? "-" : "+") + preamble + line
                };
                //do not refactor, there are no breakpoints condition in VS Experss
                if (currentPos <= selectionPosition + selectionLength && currentPos + line.Length >= selectionPosition)
                            //if the last line is selected to be reset and there is no new line at the end of file
                            //then we also have to remove the last not selected line in order to add it right again with the "No newline.." indicator
                            PatchLine lastNotSelectedLine = result.CurrentSubChunk.RemovedLines.LastOrDefault(aLine => !aLine.Selected);

            foreach (SubChunk subChunk in SubChunks)
            diff = "@@ -" + StartLine + "," + removedCount + " +" + StartLine + "," + addedCount + " @@".Combine("\n", diff);

        public static ChunkList GetSelectedChunks(string text, int selectionPosition, int selectionLength, bool staged, out string header)
            //When there is no patch, return nothing
            string[] chunks = diff.Split(new string[] { "\n@@" }, StringSplitOptions.RemoveEmptyEntries);
                //if selection intersects with chunsk
        public static ChunkList FromNewFile(GitModule module, string text, int selectionPosition, int selectionLength, bool reset, byte[] FilePreabmle, Encoding fileContentEncoding)
            Chunk chunk = Chunk.FromNewFile(module, text, selectionPosition, selectionLength, reset, FilePreabmle, fileContentEncoding);
            ChunkList result = new ChunkList();
            result.Add(chunk);
            return result;
            SubChunkToPatchFnc subChunkToPatch = (SubChunk subChunk, ref int addedCount, ref int removedCount, ref bool wereSelectedLines) =>
                {
                    return subChunk.ToResetUnstagedLinesPatch(ref addedCount, ref removedCount, ref wereSelectedLines);
                };
            return ToPatch(subChunkToPatch);
            SubChunkToPatchFnc subChunkToPatch = (SubChunk subChunk, ref int addedCount, ref int removedCount, ref bool wereSelectedLines) =>
            };
            return ToPatch(subChunkToPatch);




