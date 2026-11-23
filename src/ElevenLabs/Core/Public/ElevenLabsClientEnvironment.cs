namespace ElevenLabs;

[Serializable]
public class ElevenLabsClientEnvironment
{
    public static readonly ElevenLabsClientEnvironment Production = new ElevenLabsClientEnvironment
    {
        Base = "https://api.elevenlabs.io",
        Production = "wss://api.elevenlabs.io",
        ProductionUs = "wss://api.us.elevenlabs.io",
        ProductionEu = "wss://api.eu.residency.elevenlabs.io",
        ProductionIndia = "wss://api.in.residency.elevenlabs.io",
        ProductionSingapore = "wss://api.sg.residency.elevenlabs.io",
    };

    public static readonly ElevenLabsClientEnvironment ProductionUs =
        new ElevenLabsClientEnvironment
        {
            Base = "https://api.us.elevenlabs.io",
            Production = "wss://api.elevenlabs.io",
            ProductionUs = "wss://api.us.elevenlabs.io",
            ProductionEu = "wss://api.eu.residency.elevenlabs.io",
            ProductionIndia = "wss://api.in.residency.elevenlabs.io",
            ProductionSingapore = "wss://api.sg.residency.elevenlabs.io",
        };

    public static readonly ElevenLabsClientEnvironment ProductionEu =
        new ElevenLabsClientEnvironment
        {
            Base = "https://api.eu.residency.elevenlabs.io",
            Production = "wss://api.elevenlabs.io",
            ProductionUs = "wss://api.us.elevenlabs.io",
            ProductionEu = "wss://api.eu.residency.elevenlabs.io",
            ProductionIndia = "wss://api.in.residency.elevenlabs.io",
            ProductionSingapore = "wss://api.sg.residency.elevenlabs.io",
        };

    public static readonly ElevenLabsClientEnvironment ProductionIndia =
        new ElevenLabsClientEnvironment
        {
            Base = "https://api.in.residency.elevenlabs.io",
            Production = "wss://api.elevenlabs.io",
            ProductionUs = "wss://api.us.elevenlabs.io",
            ProductionEu = "wss://api.eu.residency.elevenlabs.io",
            ProductionIndia = "wss://api.in.residency.elevenlabs.io",
            ProductionSingapore = "wss://api.sg.residency.elevenlabs.io",
        };

    public static readonly ElevenLabsClientEnvironment ProductionSingapore =
        new ElevenLabsClientEnvironment
        {
            Base = "https://api.sg.residency.elevenlabs.io",
            Production = "wss://api.elevenlabs.io",
            ProductionUs = "wss://api.us.elevenlabs.io",
            ProductionEu = "wss://api.eu.residency.elevenlabs.io",
            ProductionIndia = "wss://api.in.residency.elevenlabs.io",
            ProductionSingapore = "wss://api.sg.residency.elevenlabs.io",
        };

    /// <summary>
    /// URL for the base service
    /// </summary>
    public string Base { get;
#if NET5_0_OR_GREATER
        init;
#else
        set;
#endif
    }

    /// <summary>
    /// URL for the Production service
    /// </summary>
    public string Production { get;
#if NET5_0_OR_GREATER
        init;
#else
        set;
#endif
    }

    /// <summary>
    /// URL for the Production-US service
    /// </summary>
    public string ProductionUs { get;
#if NET5_0_OR_GREATER
        init;
#else
        set;
#endif
    }

    /// <summary>
    /// URL for the Production-EU service
    /// </summary>
    public string ProductionEu { get;
#if NET5_0_OR_GREATER
        init;
#else
        set;
#endif
    }

    /// <summary>
    /// URL for the Production-India service
    /// </summary>
    public string ProductionIndia { get;
#if NET5_0_OR_GREATER
        init;
#else
        set;
#endif
    }

    /// <summary>
    /// URL for the Production-Singapore service
    /// </summary>
    public string ProductionSingapore { get;
#if NET5_0_OR_GREATER
        init;
#else
        set;
#endif
    }
}
