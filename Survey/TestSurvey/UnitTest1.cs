using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Survey;
using System.Diagnostics;

namespace TestSurvey
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Test_ORM()
        {
            TestSessionContext context = new TestSessionContext();

        }

        [TestMethod]
        public void Test_TypeName()
        {
            string t1 = typeof(ValueQuestion<string>).FullName;
            string t2 = typeof(ValueQuestion<int>).FullName;
            string t3 = typeof(ValueQuestion<DateTime>).FullName;
            string t4 = typeof(ValueQuestion<float>).FullName;
        }

        [TestMethod]
        public void TestMethod1()
        {

            SurveySection s = new SurveySection();

            LikertQuestion lg = new LikertQuestion
            {
                Choices = new List<Choice>
                {
                    new Choice { SequenceNo = 1, Weight = 1, Title = "Strongly Disagree" },
                    new Choice { SequenceNo = 2, Weight = 2, Title = "Disagree" },
                    new Choice { SequenceNo = 3, Weight = 3, Title = "Neither" },
                    new Choice { SequenceNo = 4, Weight = 4, Title = "Agree" },
                    new Choice { SequenceNo = 5, Weight = 5, Title = "Strongly Agree" },
                },
                Children = new List<LikertItem>
                {
                    new LikertItem { SequenceNo = 1, Title ="My supervisor/manager says a good word when he/she sees a job done according to established patient safety procedures" },
                    new LikertItem { SequenceNo = 2, Title ="My supervisor/manager seriously considers staff suggestions for improving patient safety" },
                    new LikertItem { SequenceNo = 3, Title ="Whenever pressure builds up, my supervisor/manager wants us to work faster, even if it means taking shortcuts" },
                },
                MaxNumberOfSelection = 5,
            };

            ChoiceQuestion questionOOADIsFun = new ChoiceQuestion
            {
                SequenceNo = 1,
                Title = "OOAD is fun.",
                MaxNumberOfSelection = 1,
                MinNumberOfSelection = 1,
                Choices = new List<Choice>
                {
                    new Choice { SequenceNo = 1, Weight = 1, Title = "Strongly Disagree" },
                    new Choice { SequenceNo = 2, Weight = 2, Title = "Disagree" },
                    new Choice { SequenceNo = 3, Weight = 3, Title = "Neither" },
                    new Choice { SequenceNo = 4, Weight = 4, Title = "Agree" },
                    new Choice { SequenceNo = 5, Weight = 5, Title = "Strongly Agree" },
                    //new Choice 
                    //{ 
                    //    SequenceNo = 6, Weight = 5, Title = "Other. Please specify.",
                    //    FurtherQuestion = new Question<string>()
                    //},
                }
            };

            ValueQuestion<int> intQ = new ValueQuestion<int> { DefaultValue = 1 };
            ValueQuestion<string> stringQ = new ValueQuestion<string> { DefaultValue = "N/A" };

            foreach (SurveyItem i in s.Children)
            {
            }

        }

        [TestMethod]
        public void Test_Create_and_Persist_Survey_Form1()
        {
            //Create a survey form with one choice question
            SurveyForm f1 = new SurveyForm
            {
                EffectivePeriod = new TimeInterval(DateTime.Now),
                Title = "Survey Form 1",
                Instructions = "Please answer all the questions.",
                Questions = new List<SurveyQuestion>
                {
                    new SurveySection //0 
                    {
                        Title = "First section",
                        Children = new List<SurveyQuestion>
                        {
                            new SurveySection  //0 
                            {
                                Title = "Personal Information",
                                Children = new List<SurveyQuestion>
                                {
                                    new ChoiceQuestion
                                    {
                                        Title = "Your gender is",
                                        Choices = new List<Choice>{ new Choice { Title = "Male" }, new Choice { Title = "Female" }, }
                                    },
                                    new ValueQuestion<int>
                                    {
                                        Title = "Your age is", Suffix = "years", MinValue = 10, MaxValue = 120, DefaultValue =30
                                    },
                                    new ValueQuestion<DateTime>
                                    {
                                        Title = "Your birth date is", 
                                        MinValue = new DateTime(1940, 01, 01), 
                                        MaxValue = new DateTime(2000, 04, 06),
                                        DefaultValue = new DateTime(1940, 01, 01), 
                                    },
                                },
                            },
                            new SurveySection //1
                            {
                                Title = "Marriage",
                                Children = new List<SurveyQuestion>
                                {
                                    new ChoiceQuestion //0
                                    {
                                        Title = "What is you marriage status?",
                                        Choices = new List<Choice>
                                        { 
                                            new Choice 
                                            { 
                                                Title = "สมรส",
                                                FurtherQuestion = new ValueQuestion<int> { Title = "Your spouse age is ", Suffix = "years", DefaultValue = 5 },
                                            }, 
                                            new Choice { Title = "โสด" }, 
                                            new Choice { Title = "หม้าย" }, 
                                        }
                                    },
                                },
                            },
                        },
                    },
                    new SurveySection 
                    {
                        Title = "Education",
                        Children = new List<SurveyQuestion>
                        {
                            new ChoiceQuestion
                            {
                                Title = "Your education level is",
                                Choices = new List<Choice>
                                {
                                    new Choice { Title = "Doctoral degree" },
                                    new Choice { Title = "Master degree" },
                                    new Choice { Title = "Bachelor degree" },
                                    new Choice { Title = "High school diploma" },
                                    new Choice { Title = "Below high school" },
                                },
                            },
                            new LikertQuestion
                            {
                                Title = "Section B: Your Supervisor/Manager",
                                Instructions = "Please indicate your agreement or disagreement with the following statements about your immediate supervisor/manager or person to whom you directly report. Mark your answer by filling in the circle.",
                                Choices = new List<Choice>
                                {
                                    new Choice { Weight = 1, Title = "Strongly Disagree" },
                                    new Choice { Weight = 2, Title = "Disagree" },
                                    new Choice { Weight = 3, Title = "Neither" },
                                    new Choice { Weight = 4, Title = "Agree" },
                                    new Choice { Weight = 5, Title = "Strongly Agree" },
                                },
                                Children = new List<LikertItem>
                                {
                                    new LikertItem { Title = "My supervisor/manager says a good word when he/she sees a job done according to established patient safety procedures" },
                                    new LikertItem { Title = "My supervisor/manager seriously considers staff suggestions for improving patient safety" },
                                    new LikertItem { Title = "Whenever pressure builds up, my supervisor/manager wants us to work faster, even if it means taking shortcuts" },
                                    new LikertItem { Title = "My supervisor/manager overlooks patient safety problems that happen over and over" },
                                }
                            }
                        },
                    },
                }
            };
            TestSessionContext context = new TestSessionContext();
            context.PersistenceSession.BeginTransaction();
            try
            {
                f1.Persist(context);
                context.PersistenceSession.Transaction.Commit();
            }
            catch
            {
                context.PersistenceSession.Transaction.Rollback();
                throw;
            }
            context.Close();
        }

        [TestMethod]
        public void Test_Getting_A_Persisted_Survey_Form()
        {
            DateTime today = DateTime.Today;
            TestSessionContext context = new TestSessionContext();

            SurveyForm f = context.PersistenceSession
                                .QueryOver<SurveyForm>()
                                .Where(t => t.Title == "HOSPITAL SURVEY ON PATIENT SAFETY CULTURE")
                                .SingleOrDefault();
        }

        [TestMethod]
        public void Test_Create_and_Persist_A_Response_Of_SurveyForm1()
        {
            DateTime now = DateTime.Now;
            TestSessionContext context = new TestSessionContext();
            SurveyForm f = context.PersistenceSession
                                .QueryOver<SurveyForm>()
                                .Where(t => t.Title == "Survey Form 1"
                                            && t.EffectivePeriod.From <= now
                                            && t.EffectivePeriod.To > now)
                                .SingleOrDefault();

            var s1 = (SurveySection)f.Questions[0];
            var s1_1 = s1.Children[1] as SurveySection;
            var q1_1_1 = (ChoiceQuestion)s1_1.Children[0]; //Marriage
            var choice1_1_1_1 = q1_1_1.Choices[0]; //Married
            var fq = choice1_1_1_1.FurtherQuestion;
            var fqName = fq.GetType().FullName;

            ResponseForm r1 = new ResponseForm(f);
            r1.Responses = CreateDefaultResponses(f.Questions);

            //ResponseForm r2 = f.CreateDefaultResponse();

            //r1.Persist(context);
        }

        private IList<Response> CreateDefaultResponses(IList<SurveyQuestion> questions)
        {
            IList<Response> responses = new List<Response>();
            foreach (SurveyQuestion q in questions)
            {
                Response r = null;
                if (q is SurveySection)
                    r = CreateDefaultResponseSection((SurveySection)q);
                else if (q is LikertQuestion)
                    r = CreateDefaultLikertResponse((LikertQuestion)q);
                else if (q is ChoiceQuestion)
                    r = CreateDefaultChoiceResponse((ChoiceQuestion)q);
                else if (q is ValueQuestion<int>)
                    r = CreateDefaultValueResponse<int>((ValueQuestion<int>)q);
                else if (q is ValueQuestion<DateTime>)
                    r = CreateDefaultValueResponse<DateTime>((ValueQuestion<DateTime>)q);
                else if (q is ValueQuestion<String>)
                    r = CreateDefaultValueResponse<String>((ValueQuestion<String>)q);
                responses.Add(r);
            }

            return responses;
        }

        private LikertResponse CreateDefaultLikertResponse(LikertQuestion q)
        {
            LikertResponse r = new LikertResponse { Question = q };
            foreach (LikertItem i in q.Children)
            {
                r.ItemResponses.Add(new LikertItemResponse { LikertItem = i, Choice = q.Choices[0] });
            }
            return r;
        }

        private ValueResponse<T1> CreateDefaultValueResponse<T1>(ValueQuestion<T1> q)
        {
            ValueResponse<T1> r = new ValueResponse<T1>(q, q.DefaultValue);
            return r;
        }

        private ChoiceResponse CreateDefaultChoiceResponse(ChoiceQuestion q)
        {
            ChoiceResponse r = new ChoiceResponse(q);
            for (int i = 0; i < q.MinNumberOfSelection; ++i)
            {
                r.SelectedChoices.Add(new ResponseChoice(r, q.Choices[i]));
            }
            return r;
        }

        private ResponseSection CreateDefaultResponseSection(SurveySection q)
        {
            ResponseSection r = new ResponseSection(q);
            r.Children = CreateDefaultResponses(q.Children);
            return r;
        }

        [TestMethod]
        public void Test_Create_and_Persist_Hospital_Survey()
        {
            //Create hospital survey on patient safety culture
            SurveyForm f1 = new SurveyForm
            {
                EffectivePeriod = new TimeInterval(DateTime.Now),
                Title = "HOSPITAL SURVEY ON PATIENT SAFETY CULTURE",
                Instructions = "This survey asks for your opinions about patient safety issues, medical error, and event reporting in your hospital and will take about 10 to 15 minutes to complete.",
                EndNote = "If you do not wish to answer a question, or if a question does not apply to you, you may leave your answer blank.",
                Questions = new List<SurveyQuestion>
                {
                    new SurveySection //0 
                    {
                        Title = "SECTION A: Your Work Area/Unit",
                        Instructions = "In this survey, think of your “unit” as the work area, department, or clinical area of the hospital where you spend most of your work time or provide most of your clinical services.",
                        Children = new List<SurveyQuestion>
                        {
                            new ChoiceQuestion
                            {
                                Title = "What is your primary work area or unit in this hospital? Mark ONE answer by filling in the circle.",
                                Choices = new List<Choice>{ 
                                                            new Choice { Title = "a. Many different hospital units/No specific unit" }, 
                                                            new Choice { Title = "b. Medicine (nonsurgical)" }, 
                                                            new Choice { Title = "c. Surgery" }, 
                                                            new Choice { Title = "d. Obstetrics" },
                                                            new Choice { Title = "e. Pediatrics" }, 
                                                            new Choice { Title = "f. Emergency department" },
                                                            new Choice { Title = "g. Intensive care unit (any type)" }, 
                                                            new Choice { Title = "h. Psychiatry/mental health" },
                                                            new Choice { Title = "i. Rehabilitation" }, 
                                                            new Choice { Title = "j. Pharmacy" },
                                                            new Choice { Title = "k. Laboratory" }, 
                                                            new Choice { Title = "l. Radiology" },
                                                            new Choice { Title = "m. Anesthesiology" }, 
                                                            new Choice { Title = "n. Other, please specify:", FurtherQuestion = new ValueQuestion<string> { MaxValue = "255" } },
                                                          }
                            },
                            new LikertQuestion
                            {
                                Title = "Please indicate your agreement or disagreement with the following statements about your work area/unit. Mark your answer by filling in the circle.",
                                Instructions = "Think about your hospital work area/unit…",
                                Choices = new List<Choice>
                                {
                                    new Choice { Weight = 1, Title = "Strongly Disagree" },
                                    new Choice { Weight = 2, Title = "Disagree" },
                                    new Choice { Weight = 3, Title = "Neither" },
                                    new Choice { Weight = 4, Title = "Agree" },
                                    new Choice { Weight = 5, Title = "Strongly Agree" },
                                },
                                Children = new List<LikertItem>
                                {
                                    new LikertItem { Title = "1. People support one another in this unit" },
                                    new LikertItem { Title = "2. We have enough staff to handle the workload" },
                                    new LikertItem { Title = "3. When a lot of work needs to be done quickly, we work together as a team to get the work done" },
                                    new LikertItem { Title = "4. In this unit, people treat each other with respect" },
                                    new LikertItem { Title = "5. Staff in this unit work longer hours than is best for patient care" },
                                    new LikertItem { Title = "6. We are actively doing things to improve patient safety" },
                                    new LikertItem { Title = "7. We use more agency/temporary staff than is best for patient care" },
                                    new LikertItem { Title = "8. Staff feel like their mistakes are held against them" },
                                    new LikertItem { Title = "9. Mistakes have led to positive changes here" },
                                    new LikertItem { Title = "10. It is just by chance that more serious mistakes don’t happen around here" },
                                    new LikertItem { Title = "11. When one area in this unit gets really busy, others help out" },
                                    new LikertItem { Title = "12. When an event is reported, it feels like the person is being written up, not the problem" },
                                    new LikertItem { Title = "13. After we make changes to improve patient safety, we evaluate their effectiveness" },
                                    new LikertItem { Title = "14. We work in \"crisis mode\" trying to do too much, too quickly" },
                                    new LikertItem { Title = "15. Patient safety is never sacrificed to get more work done" },
                                    new LikertItem { Title = "16. Staff worry that mistakes they make are kept in their    personnel file" },
                                    new LikertItem { Title = "17. We have patient safety problems in this unit" },
                                    new LikertItem { Title = "18. Our procedures and systems are good at preventing errors from happening" },
                                }
                            }, 
                        },
                    },
                    new SurveySection //1 
                    {
                        Title = "SECTION B: Your Supervisor/Manager",
                        Children = new List<SurveyQuestion>
                        {
                            new LikertQuestion
                            {
                                Title = "Please indicate your agreement or disagreement with the following statements about your immediate supervisor/manager or person to whom you directly report. Mark your answer by filling in the circle.",
                                Choices = new List<Choice>
                                {
                                    new Choice { Weight = 1, Title = "Strongly Disagree" },
                                    new Choice { Weight = 2, Title = "Disagree" },
                                    new Choice { Weight = 3, Title = "Neither" },
                                    new Choice { Weight = 4, Title = "Agree" },
                                    new Choice { Weight = 5, Title = "Strongly Agree" },
                                },
                                Children = new List<LikertItem>
                                {
                                    new LikertItem { Title = "1. My supervisor/manager says a good word when he/she sees a job done according to established patient safety procedures" },
                                    new LikertItem { Title = "2. My supervisor/manager seriously considers staff suggestions for improving patient safety" },
                                    new LikertItem { Title = "3. Whenever pressure builds up, my supervisor/manager wants us to work faster, even if it means taking shortcuts" },
                                    new LikertItem { Title = "4. My supervisor/manager overlooks patient safety problems that happen over and over" },
                                }
                            }, 
                        },
                    },
                    new SurveySection //2
                    {
                        Title = "SECTION C: Communications",
                        Children = new List<SurveyQuestion>
                        {
                            new LikertQuestion
                            {
                                Title = "How often do the following things happen in your work area/unit? Mark your answer by filling in the circle.",
                                Instructions = "Think about your hospital work area/unit…",
                                Choices = new List<Choice>
                                {
                                    new Choice { Weight = 1, Title = "Never" },
                                    new Choice { Weight = 2, Title = "Rarely" },
                                    new Choice { Weight = 3, Title = "Some-times" },
                                    new Choice { Weight = 4, Title = "Most of the time" },
                                    new Choice { Weight = 5, Title = "Always" },
                                },
                                Children = new List<LikertItem>
                                {
                                    new LikertItem { Title = "1. We are given feedback about changes put into place based on event reports" },
                                    new LikertItem { Title = "2. Staff will freely speak up if they see something that may negatively affect patient care" },
                                    new LikertItem { Title = "3. We are informed about errors that happen in this unit" },
                                    new LikertItem { Title = "4. Staff feel free to question the decisions or actions of those with more authority" },
                                    new LikertItem { Title = "5. In this unit, we discuss ways to prevent errors from happening again" },
                                    new LikertItem { Title = "6. Staff are afraid to ask questions when something does not seem right" },
                                }
                            }, 
                        },
                    },
                    new SurveySection //3
                    {
                        Title = "SECTION D: Frequency of Events Reported",
                        Children = new List<SurveyQuestion>
                        {
                            new LikertQuestion
                            {
                                Title = "In your hospital work area/unit, when the following mistakes happen, how often are they reported? Mark your answer by filling in the circle.",
                                Choices = new List<Choice>
                                {
                                    new Choice { Weight = 1, Title = "Never" },
                                    new Choice { Weight = 2, Title = "Rarely" },
                                    new Choice { Weight = 3, Title = "Some-times" },
                                    new Choice { Weight = 4, Title = "Most of the time" },
                                    new Choice { Weight = 5, Title = "Always" },
                                },
                                Children = new List<LikertItem>
                                {
                                    new LikertItem { Title = "1. When a mistake is made, but is caught and corrected before affecting the patient, how often is this reported?" },
                                    new LikertItem { Title = "2. When a mistake is made, but has no potential to harm the patient, how often is this reported?" },
                                    new LikertItem { Title = "3. When a mistake is made that could harm the patient, but does not, how often is this reported?" },
                                }
                            }, 
                        },
                    },
                    new SurveySection //4
                    {
                        Title = "SECTION E: Patient Safety Grade",
                        Children = new List<SurveyQuestion>
                        {
                            new ChoiceQuestion
                            {
                                Title = "Please give your work area/unit in this hospital an overall grade on patient safety.  Mark ONE answer.",
                                Choices = new List<Choice>{ 
                                                            new Choice { Title = "A Excellent" }, 
                                                            new Choice { Title = "B Very Good" }, 
                                                            new Choice { Title = "C Acceptable" }, 
                                                            new Choice { Title = "D Poor" },
                                                            new Choice { Title = "E Failing" }, 
                                                          }
                            },
                        },
                    },
                    new SurveySection //5
                    {
                        Title = "SECTION F: Your Hospital",
                        Children = new List<SurveyQuestion>
                        {
                            new LikertQuestion
                            {
                                Title = "Please indicate your agreement or disagreement with the following statements about your hospital.  Mark your answer by filling in the circle.",
                                Instructions = "Think about your hospital…",
                                Choices = new List<Choice>
                                {
                                    new Choice { Weight = 1, Title = "Strongly Disagree" },
                                    new Choice { Weight = 2, Title = "Disagree" },
                                    new Choice { Weight = 3, Title = "Neither" },
                                    new Choice { Weight = 4, Title = "Agree" },
                                    new Choice { Weight = 5, Title = "Strongly Agree" },
                                },
                                Children = new List<LikertItem>
                                {
                                    new LikertItem { Title = "1. Hospital management provides a work climate that promotes patient safety" },
                                    new LikertItem { Title = "2. Hospital units do not coordinate well with each other" },
                                    new LikertItem { Title = "3. Things “fall between the cracks” when transferring patients from one unit to another" },
                                    new LikertItem { Title = "4. There is good cooperation among hospital units that need to work together" },
                                    new LikertItem { Title = "5. Important patient care information is often lost during shift changes" },
                                    new LikertItem { Title = "6. It is often unpleasant to work with staff from other hospital units" },
                                    new LikertItem { Title = "7. Problems often occur in the exchange of information across hospital units" },
                                    new LikertItem { Title = "8. The actions of hospital management show that patient safety is a top priority" },
                                    new LikertItem { Title = "9. Hospital management seems interested in patient safety only after an adverse event happens" },
                                    new LikertItem { Title = "10. Hospital units work well together to provide the best care for patients" },
                                    new LikertItem { Title = "11. Shift changes are problematic for patients in this hospital" },
                                }
                            }, 
                        },
                    },
                    new SurveySection //6
                    {
                        Title = "SECTION G: Number of Events Reported",
                        Children = new List<SurveyQuestion>
                        {
                            new ChoiceQuestion
                            {
                                Title = "In the past 12 months, how many event reports have you filled out and submitted? Mark ONE answer.",
                                Choices = new List<Choice>{ 
                                                            new Choice { Title = "a. No event reports" }, 
                                                            new Choice { Title = "b. 1 to 2 event reports" }, 
                                                            new Choice { Title = "c. 3 to 5 event reports" }, 
                                                            new Choice { Title = "d. 6 to 10 event reports" },
                                                            new Choice { Title = "e. 11 to 20 event reports" }, 
                                                            new Choice { Title = "f. 21 event reports or more" },
                                                          }
                            },
                        },
                    },
                    new SurveySection //7
                    {
                        Title = "SECTION H: Background Information",
                        Instructions = "This information will help in the analysis of the survey results.  Mark ONE answer by filling in the circle.",
                        Children = new List<SurveyQuestion>
                        {
                            new ChoiceQuestion
                            {
                                Title = "1.	How long have you worked in this hospital?",
                                Choices = new List<Choice>{ 
                                                            new Choice { Title = "a. Less than 1 year" }, 
                                                            new Choice { Title = "b. 1 to 5 years" }, 
                                                            new Choice { Title = "c. 6 to 10 years" }, 
                                                            new Choice { Title = "d. 11 to 15 years" },
                                                            new Choice { Title = "e. 16 to 20 years" }, 
                                                            new Choice { Title = "f. 21 years or more" },
                                                          }
                            },
                            new ChoiceQuestion
                            {
                                Title = "2.	How long have you worked in your current hospital work area/unit?",
                                Choices = new List<Choice>{ 
                                                            new Choice { Title = "a. Less than 1 year" }, 
                                                            new Choice { Title = "b. 1 to 5 years" }, 
                                                            new Choice { Title = "c. 6 to 10 years" }, 
                                                            new Choice { Title = "d. 11 to 15 years" },
                                                            new Choice { Title = "e. 16 to 20 years" }, 
                                                            new Choice { Title = "f. 21 years or more" },
                                                          }
                            },
                            new ChoiceQuestion
                            {
                                Title = "3. Typically, how many hours per week do you work in this hospital?",
                                Choices = new List<Choice>{ 
                                                            new Choice { Title = "a. Less than 20 hours per week" }, 
                                                            new Choice { Title = "b. 20 to 39 hours per week" }, 
                                                            new Choice { Title = "c. 40 to 59 hours per week" }, 
                                                            new Choice { Title = "d. 60 to 79 hours per week" },
                                                            new Choice { Title = "e. 80 to 99 hours per week" }, 
                                                            new Choice { Title = "f. 100 hours per week or more" },
                                                          }
                            },
                            new ChoiceQuestion
                            {
                                Title = "4. What is your staff position in this hospital?  Mark ONE answer that best describes your staff position.",
                                Choices = new List<Choice>{ 
                                                            new Choice { Title = "a. Registered Nurse" }, 
                                                            new Choice { Title = "b. Physician Assistant/Nurse Practitioner" }, 
                                                            new Choice { Title = "c. LVN/LPN" }, 
                                                            new Choice { Title = "d. Patient Care Assistant/Hospital Aide/Care Partner" },
                                                            new Choice { Title = "e. Attending/Staff Physician" }, 
                                                            new Choice { Title = "f. Resident Physician/Physician in Training" },
                                                            new Choice { Title = "g. Pharmacist" },
                                                            new Choice { Title = "h. Dietician" },
                                                            new Choice { Title = "i. Unit Assistant/Clerk/Secretary" },
                                                            new Choice { Title = "j. Respiratory Therapist" },
                                                            new Choice { Title = "k. Physical, Occupational, or Speech Therapist" },
                                                            new Choice { Title = "l. Technician (e.g., EKG, Lab, Radiology)" },
                                                            new Choice { Title = "m. Administration/Management" },
                                                            new Choice { Title = "n. Other, please specify:", FurtherQuestion = new ValueQuestion<string> { MaxValue = "255" } },
                                                          }
                            },
                            new ChoiceQuestion
                            {
                                Title = "5. In your staff position, do you typically have direct interaction or contact with patients? ",
                                Choices = new List<Choice>{ 
                                                            new Choice { Title = "a. YES, I typically have direct interaction or contact with patients." }, 
                                                            new Choice { Title = "b. NO, I typically do NOT have direct interaction or contact with patients." }, 
                                                          }
                            },
                            new ChoiceQuestion
                            {
                                Title = "6. How long have you worked in your current specialty or profession?",
                                Choices = new List<Choice>{ 
                                                            new Choice { Title = "a. Less than 1 year" }, 
                                                            new Choice { Title = "b. 1 to 5 years" }, 
                                                            new Choice { Title = "c. 6 to 10 years" }, 
                                                            new Choice { Title = "d. 11 to 15 years" },
                                                            new Choice { Title = "e. 16 to 20 years" }, 
                                                            new Choice { Title = "f. 21 years or more" },
                                                          }
                            },
                        },
                    },
                    new SurveySection //8
                    {
                        Title = "SECTION I: Your Comments",
                        Children = new List<SurveyQuestion>
                        {
                            new ValueQuestion<string>
                            {
                                Title = "Please feel free to write any comments about patient safety, error, or event reporting in your hospital.",  
                                MaxValue = "2000"
                            },
                        },
                    },
                }
            };
            TestSessionContext context = new TestSessionContext();
            context.PersistenceSession.BeginTransaction();
            try
            {
                f1.Persist(context);
                context.PersistenceSession.Transaction.Commit();
            }
            catch
            {
                context.PersistenceSession.Transaction.Rollback();
                throw;
            }
            context.Close();
        }   
    }
}
