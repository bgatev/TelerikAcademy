namespace WolfRaider.DatabaseAccess.AdoNET
{
    using System;
    using System.Data.Entity.Infrastructure;

    using WolfRaider.Common.Config;
    using WolfRaider.DatabaseAccess.Commands.Contracts;
    using WolfRaider.DatabaseAccess.Connections.Contracts;
    using WolfRaider.DatabaseAccess.Parameters.Contracts;

    public abstract class CommonDao
    {
        private IDatabaseConnection databaseConnection;
        private IDatabaseCommandStrategy commandStrategy;
        private IDatabaseParameterStrategy parameterStrategy;

        protected CommonDao(IDatabaseConnection databaseConnection, IDatabaseCommandStrategy commandStrategy, IDatabaseParameterStrategy parameterStrategy)
        {
            this.DatabaseConnection = databaseConnection;
            this.CommandStrategy = commandStrategy;
            this.ParameterStrategy = parameterStrategy;
        }

        protected IDatabaseConnection DatabaseConnection
        {
            get
            {
                return this.databaseConnection;
            }

            private set
            {
                if (value == null)
                {
                    string message = string.Format(ExceptionMessage.ParameterCannotBeNull, typeof(IDatabaseConnection));
                    throw new ArgumentNullException(message);
                }

                this.databaseConnection = value;
            }
        }

        protected IDatabaseCommandStrategy CommandStrategy
        {
            get
            {
                return this.commandStrategy;
            }

            private set
            {
                if (value == null)
                {
                    string message = string.Format(ExceptionMessage.ParameterCannotBeNull, typeof(IDatabaseCommandStrategy));
                    throw new ArgumentNullException(message);
                }

                this.commandStrategy = value;
            }
        }

        protected IDatabaseParameterStrategy ParameterStrategy
        {
            get
            {
                return this.parameterStrategy;
            }

            private set
            {
                if (value == null)
                {
                    string message = string.Format(ExceptionMessage.ParameterCannotBeNull, typeof(IDatabaseParameterStrategy));
                    throw new ArgumentNullException(message);
                }

                this.parameterStrategy = value;
            }
        }

        protected void CheckAffectedRows(int affectedRows, Type inClass, Type forClass, string message)
        {
            if (affectedRows == 0)
            {
                string finalMessage = string.Format(message, inClass, forClass);
                throw new DbUpdateException(finalMessage);
            }
        }
    }
}
