using BerlinClock.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private readonly ITimeParser parser;
        private readonly IPresenter presenter;

        public TimeConverter(ITimeParser parser, IPresenter presenter)
        {
            this.parser = parser;
            this.presenter = presenter;
        }

        public string convertTime(string aTime)
        {
            var parsedTime = parser.Parse(aTime);
            return presenter.GetView(parsedTime);
        }
    }
}
