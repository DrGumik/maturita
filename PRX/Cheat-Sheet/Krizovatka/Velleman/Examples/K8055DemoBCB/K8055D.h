#ifdef __cplusplus
extern "C" {
#endif

#define FUNCTION __declspec(dllimport)

FUNCTION int __stdcall OpenDevice(int CardAddress);
FUNCTION void __stdcall CloseDevice();
FUNCTION int __stdcall ReadAnalogChannel(int Channel);
FUNCTION void __stdcall ReadAllAnalog(int *Data1, int *Data2);
FUNCTION void __stdcall OutputAnalogChannel(int Channel, int Data);
FUNCTION void __stdcall OutputAllAnalog(int Data1, int Data2);
FUNCTION void __stdcall ClearAnalogChannel(int Channel);
FUNCTION void __stdcall ClearAllAnalog();
FUNCTION void __stdcall SetAnalogChannel(int Channel);
FUNCTION void __stdcall SetAllAnalog();
FUNCTION void __stdcall WriteAllDigital(int Data);
FUNCTION void __stdcall ClearDigitalChannel(int Channel);
FUNCTION void __stdcall ClearAllDigital();
FUNCTION void __stdcall SetDigitalChannel(int Channel);
FUNCTION void __stdcall SetAllDigital();
FUNCTION bool __stdcall ReadDigitalChannel(int Channel);
FUNCTION int __stdcall ReadAllDigital();
FUNCTION int __stdcall ReadCounter(int CounterNr);
FUNCTION void __stdcall ResetCounter(int CounterNr);
FUNCTION void __stdcall SetCounterDebounceTime(int CounterNr, int DebounceTime); 
FUNCTION int __stdcall Version();
FUNCTION int __stdcall SearchDevices();
FUNCTION int __stdcall SetCurrentDevice(int CardAddress);

#ifdef __cplusplus
}
#endif



