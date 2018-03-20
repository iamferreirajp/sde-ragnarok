using Utilities.Commands;

namespace SDE.Editor.Engines.DatabaseEngine
{
    /// <summary>
    /// Holds commands for the database engine
    /// </summary>
    public class CommandsHolder : AbstractCommand<IGenericDbCommand> {
        private bool isModified;

        public bool GetIsModified()
        {
            return isModified;
        }

        internal void SetIsModified(bool value)
        {
            isModified = value;
        }

        protected override void _execute(IGenericDbCommand command) {
			command.Execute();
		}

		protected override void _undo(IGenericDbCommand command) {
			command.Undo();
		}

		protected override void _redo(IGenericDbCommand command) {
			command.Execute();
		}
	}
}