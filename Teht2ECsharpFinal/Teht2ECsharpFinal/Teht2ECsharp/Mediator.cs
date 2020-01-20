using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teht2ECsharp
{
    class Mediator
    {
         private static Mediator instance = new Mediator();
        public static Mediator Instance
        {
            get
            {
                return instance;
            }
        }
        //Tehtävänannon vaatima piilotettu konstruktori ilman toimintaa.
        private Mediator()
        {
            
        }
        public event EventHandler<JobChangedEventArgs> JobChanged;

        public void OnJobChanged(object sender, Job job)
        {
            var jobChangeDelegate = JobChanged as EventHandler<JobChangedEventArgs>;

            if (jobChangeDelegate != null)
            {
                jobChangeDelegate(sender, new JobChangedEventArgs() { Job = job });
            }
        }
    }
}
