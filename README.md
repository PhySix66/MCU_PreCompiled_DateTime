# MCU_PreCompiled_DateTime
a simple argumentless cli code for the creation of date and time file built in Visual Studio 2019

This is simple argumentless cli code that has only one function.
If called this "spits out" the current date and time values in multiple formats.
I've mede this specialy for my MCU(AVR) projects to always get an Updated Date/Time value.

Add to Makefile:	
...	
all: begin version gccversion sizebefore build sizeafter end	
...	
VERSION_FILE = version.h	

version: $(VERSION_FILE)	
	@echo '#ifndef		_VERSION_H_' > $(VERSION_FILE) 
	@echo '#define		_VERSION_H_' >> $(VERSION_FILE)	
	@echo '#include	<avr/pgmspace.h>' >> $(VERSION_FILE) 
	@echo '//data from date_precompiled.exe' >> $(VERSION_FILE)	
	@DateTime_PreCompiled >> $(VERSION_FILE)	
	@echo '#endif' >> $(VERSION_FILE)	

.PHONY:	version.h	

OutPut:	

#ifndef		_VERSION_H_
#define		_VERSION_H_
#include	<avr/pgmspace.h>
//data from date_precompiled.exe
#define PRECOMPILED_UTC_OFFSET	        0200
#define PRECOMPILED_UTC_HOUR_OFFSET	2
#define PRECOMPILED_UTC_MIN_OFFSET	0
#define PRECOMPILED_GMT_HOUR_OFFSET  1

#define PRECOMPILED_BIT_AM_PM    1       //  AM = 0, PM = 1
#define PRECOMPILED_BIT_DST	    1       //  DayLight Saving Time, yes = 1, no = 0
#define PRECOMPILED_BIT_LEAP	    0       //  LeapYear, yes = 1, no = 0

#define PRECOMPILED_DEC_MSEC	    393       //  MilliSeconds (0...999)
#define PRECOMPILED_DEC_SEC	    35       //  Seconds (0...59)
#define PRECOMPILED_DEC_MIN	    12       //  Minutes (0...59)
#define PRECOMPILED_DEC_HOUR	    12       //  Hours (0...23)
#define PRECOMPILED_DEC_HR12	    12       //  Hours (0...12)

#define PRECOMPILED_BIT_DOW	    3       //  
#define PRECOMPILED_HEX_DOW	    8       //  
#define PRECOMPILED_DEC_DOW	    4       //  
#define PRECOMPILED_DEC_DOW_MO2SU_127  4       //  Monday to Sunday 1 to 7
#define PRECOMPILED_DEC_DOW_SU2SA_127  5       //  Sunday to Saturday 1 to 7
#define PRECOMPILED_DEC_DOW_MO2SU_026  3       //  Monday to Sunday 0 to 6
#define PRECOMPILED_DEC_DOW_SU2SA_026  4       //  Sunday to Saturday 0 to 6

#define PRECOMPILED_DEC_DOY	    272       //  Day Of Year (0...366)
#define PRECOMPILED_DEC_DOM	    29       //  Day of Month (1...31)
#define PRECOMPILED_DEC_DATE	    29       //  Day of Month (1...31)
#define PRECOMPILED_DEC_MTH	    9       //  Month (1...12)
#define PRECOMPILED_DEC_SHORT_YEAR	22       //  Years last two digits in DECimal (00...99)
#define PRECOMPILED_DEC_YEAR	    2022       //  Years in DECimal (0...till the end of time)

#define PRECOMPILED_DT_DEC_SHORT_ARRAY	{35,12,12,4,29,9,22}
#define PRECOMPILED_DT_BCD_SHORT_ARRAY	{0x35,0x12,0x12,0x08,0x29,0x09,0x22}
#define PRECOMPILED_DATE_DEC_SHORT_ARRAY	{3,29,9,{ .i = 22}}
#define PRECOMPILED_TIME_DEC_ARRAY	{35,12,12}
#define PRECOMPILED_DT_DEC_ARRAY	{0,0,0,35,12,12,4,29,9,{ .i = 22}}
#define PRECOMPILED_DATE_BCD_ARRAY	{0x04,0x29,0x09,{ .i = 0x2022}}
#define PRECOMPILED_TIME_BCD_ARRAY	{0x35,0x12,0x12}
#define PRECOMPILED_DT_BCD_ARRAY	{0,0,0,0x35,0x12,0x12,0x04,0x29,0x09,{ .i = 0x2022}}
#endif
