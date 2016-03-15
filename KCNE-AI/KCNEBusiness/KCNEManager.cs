using KCNEBusiness.Module;
using KCNEBusiness.Module.Normal;
using System;
using System.Collections.Generic;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace KCNEBusiness
{
	public delegate void StopHandler();

	public class KCNEManager
	{
		// Singleton Instance
		private static KCNEManager _instance = null;
		public static KCNEManager Instance
		{
			get
			{
				if (_instance == null)
					_instance = new KCNEManager();

				return _instance;
			}
		}

		public static event StopHandler StopEvent;

		public static readonly float[] versionNumbers =
		{
			1.0f,
			1.1f,
		};

		public const int DEFAULT_VERSION_NUMBER_INDEX = 0;

		private const string COMMAND_EXIT = "goodbye";
		private const string COMMAND_FUN_HELLO = "hello.";
		private const string COMMAND_FUN_STATUS = "how are you";
		private const string COMMAND_FUN_NAME = "what is your name";
		private const string COMMAND_FUN_PURPOSE = "what is your purpose";

		private const string COMMAND_GAME_SIMPLE_WIRES = "simple wires";

		private const string COMMAND_ANSWERS_RED = "red";
		private const string COMMAND_ANSWERS_YELLOW = "yellow";
		private const string COMMAND_ANSWERS_BLUE = "blue";
		private const string COMMAND_ANSWERS_BLACK = "black";
		private const string COMMAND_ANSWERS_WHITE = "white";

		private static readonly string[] COMMANDS =
		{
			COMMAND_EXIT,
			COMMAND_FUN_HELLO,
			COMMAND_FUN_STATUS,
			COMMAND_FUN_NAME,
			COMMAND_FUN_PURPOSE,
			COMMAND_GAME_SIMPLE_WIRES,
			COMMAND_ANSWERS_BLACK,
			COMMAND_ANSWERS_BLUE,
			COMMAND_ANSWERS_RED,
			COMMAND_ANSWERS_WHITE,
			COMMAND_ANSWERS_YELLOW
		};

		private static readonly Dictionary<string, string> KC_RESPONSES = new Dictionary<string, string>()
		{
			{ COMMAND_EXIT, "goodbye." },
			{ COMMAND_FUN_HELLO, "hello. it is me."},
			{ COMMAND_FUN_STATUS, "i am doing well." },
			{ COMMAND_FUN_NAME, "my name is K C." },
			{ COMMAND_FUN_PURPOSE, "my purpose is to serve butter. just kidding. my purpose is to help you beat the game." },
			{ COMMAND_GAME_SIMPLE_WIRES, "give me the colors."}

		};

		private SpeechRecognitionEngine _recognizer;
		private SpeechSynthesizer _synthesizer;

		//private IModule _currentModule;

		public KCNEManager()
		{
			if (_instance != null)
				throw new Exception("KCNEManager is a Singleton. Use \"KCNEManager.Instance\"");

		}

		public void Init()
		{
			Choices cmds = new Choices();
			cmds.Add(COMMANDS);

			GrammarBuilder gb = new GrammarBuilder();
			gb.Append(cmds);

			Grammar g = new Grammar(new GrammarBuilder(gb, 0, 6));

			_recognizer = new SpeechRecognitionEngine();
			_recognizer.LoadGrammarAsync(g);
			_recognizer.SetInputToDefaultAudioDevice();
			_recognizer.SpeechRecognized += OnSpeechRecognized;

			_synthesizer = new SpeechSynthesizer();
		}

		public bool Start(int versionIndex)
		{
			_recognizer.RecognizeAsync(RecognizeMode.Multiple);

			// successfully started
			return true;
		}

		public bool Stop()
		{
			_recognizer.RecognizeAsyncStop();

			// successfully stopped
			return true;
		}

		private void HandleSpeech(RecognitionResult result)
		{
			string command = result.Text;

			if (KC_RESPONSES.ContainsKey(command))
				_synthesizer.SpeakAsync(KC_RESPONSES[command]);

			switch (command)
			{
				case COMMAND_EXIT:
					if (StopEvent != null)
						StopEvent(); // dispatch stop event
					break;
				case COMMAND_GAME_SIMPLE_WIRES:
					//_currentModule = new SimpleWiresModule();
					break;
				default:
					Console.WriteLine(command);
					break;
			}
		}

		private void OnSpeechRecognized(object sender, SpeechRecognizedEventArgs e)
		{
			HandleSpeech(e.Result);
		}
	}
}
