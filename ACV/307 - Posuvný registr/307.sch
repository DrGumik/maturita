<?xml version="1.0" encoding="utf-8"?>
<!DOCTYPE eagle SYSTEM "eagle.dtd">
<eagle version="9.6.2">
<drawing>
<settings>
<setting alwaysvectorfont="no"/>
<setting keepoldvectorfont="yes"/>
<setting verticaltext="up"/>
</settings>
<grid distance="0.1" unitdist="inch" unit="inch" style="lines" multiple="1" display="no" altdistance="0.01" altunitdist="inch" altunit="inch"/>
<layers>
<layer number="1" name="Top" color="4" fill="1" visible="no" active="no"/>
<layer number="2" name="Route2" color="1" fill="3" visible="no" active="no"/>
<layer number="3" name="Route3" color="4" fill="3" visible="no" active="no"/>
<layer number="4" name="Route4" color="1" fill="4" visible="no" active="no"/>
<layer number="5" name="Route5" color="4" fill="4" visible="no" active="no"/>
<layer number="6" name="Route6" color="1" fill="8" visible="no" active="no"/>
<layer number="7" name="Route7" color="4" fill="8" visible="no" active="no"/>
<layer number="8" name="Route8" color="1" fill="2" visible="no" active="no"/>
<layer number="9" name="Route9" color="4" fill="2" visible="no" active="no"/>
<layer number="10" name="Route10" color="1" fill="7" visible="no" active="no"/>
<layer number="11" name="Route11" color="4" fill="7" visible="no" active="no"/>
<layer number="12" name="Route12" color="1" fill="5" visible="no" active="no"/>
<layer number="13" name="Route13" color="4" fill="5" visible="no" active="no"/>
<layer number="14" name="Route14" color="1" fill="6" visible="no" active="no"/>
<layer number="15" name="Route15" color="4" fill="6" visible="no" active="no"/>
<layer number="16" name="Bottom" color="1" fill="1" visible="no" active="no"/>
<layer number="17" name="Pads" color="2" fill="1" visible="no" active="no"/>
<layer number="18" name="Vias" color="2" fill="1" visible="no" active="no"/>
<layer number="19" name="Unrouted" color="6" fill="1" visible="no" active="no"/>
<layer number="20" name="Dimension" color="15" fill="1" visible="no" active="no"/>
<layer number="21" name="tPlace" color="7" fill="1" visible="no" active="no"/>
<layer number="22" name="bPlace" color="7" fill="1" visible="no" active="no"/>
<layer number="23" name="tOrigins" color="15" fill="1" visible="no" active="no"/>
<layer number="24" name="bOrigins" color="15" fill="1" visible="no" active="no"/>
<layer number="25" name="tNames" color="7" fill="1" visible="no" active="no"/>
<layer number="26" name="bNames" color="7" fill="1" visible="no" active="no"/>
<layer number="27" name="tValues" color="7" fill="1" visible="no" active="no"/>
<layer number="28" name="bValues" color="7" fill="1" visible="no" active="no"/>
<layer number="29" name="tStop" color="7" fill="3" visible="no" active="no"/>
<layer number="30" name="bStop" color="7" fill="6" visible="no" active="no"/>
<layer number="31" name="tCream" color="7" fill="4" visible="no" active="no"/>
<layer number="32" name="bCream" color="7" fill="5" visible="no" active="no"/>
<layer number="33" name="tFinish" color="6" fill="3" visible="no" active="no"/>
<layer number="34" name="bFinish" color="6" fill="6" visible="no" active="no"/>
<layer number="35" name="tGlue" color="7" fill="4" visible="no" active="no"/>
<layer number="36" name="bGlue" color="7" fill="5" visible="no" active="no"/>
<layer number="37" name="tTest" color="7" fill="1" visible="no" active="no"/>
<layer number="38" name="bTest" color="7" fill="1" visible="no" active="no"/>
<layer number="39" name="tKeepout" color="4" fill="11" visible="no" active="no"/>
<layer number="40" name="bKeepout" color="1" fill="11" visible="no" active="no"/>
<layer number="41" name="tRestrict" color="4" fill="10" visible="no" active="no"/>
<layer number="42" name="bRestrict" color="1" fill="10" visible="no" active="no"/>
<layer number="43" name="vRestrict" color="2" fill="10" visible="no" active="no"/>
<layer number="44" name="Drills" color="7" fill="1" visible="no" active="no"/>
<layer number="45" name="Holes" color="7" fill="1" visible="no" active="no"/>
<layer number="46" name="Milling" color="3" fill="1" visible="no" active="no"/>
<layer number="47" name="Measures" color="7" fill="1" visible="no" active="no"/>
<layer number="48" name="Document" color="7" fill="1" visible="no" active="no"/>
<layer number="49" name="Reference" color="7" fill="1" visible="no" active="no"/>
<layer number="51" name="tDocu" color="7" fill="1" visible="no" active="no"/>
<layer number="52" name="bDocu" color="7" fill="1" visible="no" active="no"/>
<layer number="90" name="Modules" color="5" fill="1" visible="yes" active="yes"/>
<layer number="91" name="Nets" color="2" fill="1" visible="yes" active="yes"/>
<layer number="92" name="Busses" color="1" fill="1" visible="yes" active="yes"/>
<layer number="93" name="Pins" color="2" fill="1" visible="no" active="yes"/>
<layer number="94" name="Symbols" color="4" fill="1" visible="yes" active="yes"/>
<layer number="95" name="Names" color="7" fill="1" visible="yes" active="yes"/>
<layer number="96" name="Values" color="7" fill="1" visible="yes" active="yes"/>
<layer number="97" name="Info" color="7" fill="1" visible="yes" active="yes"/>
<layer number="98" name="Guide" color="6" fill="1" visible="yes" active="yes"/>
</layers>
<schematic xreflabel="%F%N/%S.%C%R" xrefpart="/%S.%C%R">
<libraries>
<library name="74xx-eu">
<description>&lt;b&gt;TTL Devices, 74xx Series with European Symbols&lt;/b&gt;&lt;p&gt;
Based on the following sources:
&lt;ul&gt;
&lt;li&gt;Texas Instruments &lt;i&gt;TTL Data Book&lt;/i&gt;&amp;nbsp;&amp;nbsp;&amp;nbsp;Volume 1, 1996.
&lt;li&gt;TTL Data Book, Volume 2 , 1993
&lt;li&gt;National Seminconductor Databook 1990, ALS/LS Logic
&lt;li&gt;ttl 74er digital data dictionary, ECA Electronic + Acustic GmbH, ISBN 3-88109-032-0
&lt;li&gt;http://icmaster.com/ViewCompare.asp
&lt;/ul&gt;
&lt;author&gt;Created by librarian@cadsoft.de&lt;/author&gt;</description>
<packages>
<package name="DIL16">
<description>&lt;b&gt;Dual In Line Package&lt;/b&gt;</description>
<wire x1="10.16" y1="2.921" x2="-10.16" y2="2.921" width="0.1524" layer="21"/>
<wire x1="-10.16" y1="-2.921" x2="10.16" y2="-2.921" width="0.1524" layer="21"/>
<wire x1="10.16" y1="2.921" x2="10.16" y2="-2.921" width="0.1524" layer="21"/>
<wire x1="-10.16" y1="2.921" x2="-10.16" y2="1.016" width="0.1524" layer="21"/>
<wire x1="-10.16" y1="-2.921" x2="-10.16" y2="-1.016" width="0.1524" layer="21"/>
<wire x1="-10.16" y1="1.016" x2="-10.16" y2="-1.016" width="0.1524" layer="21" curve="-180"/>
<pad name="1" x="-8.89" y="-3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="2" x="-6.35" y="-3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="7" x="6.35" y="-3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="8" x="8.89" y="-3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="3" x="-3.81" y="-3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="4" x="-1.27" y="-3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="6" x="3.81" y="-3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="5" x="1.27" y="-3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="9" x="8.89" y="3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="10" x="6.35" y="3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="11" x="3.81" y="3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="12" x="1.27" y="3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="13" x="-1.27" y="3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="14" x="-3.81" y="3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="15" x="-6.35" y="3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="16" x="-8.89" y="3.81" drill="0.8128" shape="long" rot="R90"/>
<text x="-10.541" y="-2.921" size="1.27" layer="25" ratio="10" rot="R90">&gt;NAME</text>
<text x="-7.493" y="-0.635" size="1.27" layer="27" ratio="10">&gt;VALUE</text>
</package>
<package name="SO16">
<description>&lt;b&gt;Small Outline package&lt;/b&gt; 150 mil</description>
<wire x1="4.699" y1="1.9558" x2="-4.699" y2="1.9558" width="0.1524" layer="51"/>
<wire x1="4.699" y1="-1.9558" x2="5.08" y2="-1.5748" width="0.1524" layer="21" curve="90"/>
<wire x1="-5.08" y1="1.5748" x2="-4.699" y2="1.9558" width="0.1524" layer="21" curve="-90"/>
<wire x1="4.699" y1="1.9558" x2="5.08" y2="1.5748" width="0.1524" layer="21" curve="-90"/>
<wire x1="-5.08" y1="-1.5748" x2="-4.699" y2="-1.9558" width="0.1524" layer="21" curve="90"/>
<wire x1="-4.699" y1="-1.9558" x2="4.699" y2="-1.9558" width="0.1524" layer="51"/>
<wire x1="5.08" y1="-1.5748" x2="5.08" y2="1.5748" width="0.1524" layer="21"/>
<wire x1="-5.08" y1="1.5748" x2="-5.08" y2="0.508" width="0.1524" layer="21"/>
<wire x1="-5.08" y1="0.508" x2="-5.08" y2="-0.508" width="0.1524" layer="21"/>
<wire x1="-5.08" y1="-0.508" x2="-5.08" y2="-1.5748" width="0.1524" layer="21"/>
<wire x1="-5.08" y1="0.508" x2="-5.08" y2="-0.508" width="0.1524" layer="21" curve="-180"/>
<wire x1="-5.08" y1="-1.6002" x2="5.08" y2="-1.6002" width="0.0508" layer="21"/>
<smd name="1" x="-4.445" y="-3.0734" dx="0.6604" dy="2.032" layer="1"/>
<smd name="16" x="-4.445" y="3.0734" dx="0.6604" dy="2.032" layer="1"/>
<smd name="2" x="-3.175" y="-3.0734" dx="0.6604" dy="2.032" layer="1"/>
<smd name="3" x="-1.905" y="-3.0734" dx="0.6604" dy="2.032" layer="1"/>
<smd name="15" x="-3.175" y="3.0734" dx="0.6604" dy="2.032" layer="1"/>
<smd name="14" x="-1.905" y="3.0734" dx="0.6604" dy="2.032" layer="1"/>
<smd name="4" x="-0.635" y="-3.0734" dx="0.6604" dy="2.032" layer="1"/>
<smd name="13" x="-0.635" y="3.0734" dx="0.6604" dy="2.032" layer="1"/>
<smd name="5" x="0.635" y="-3.0734" dx="0.6604" dy="2.032" layer="1"/>
<smd name="12" x="0.635" y="3.0734" dx="0.6604" dy="2.032" layer="1"/>
<smd name="6" x="1.905" y="-3.0734" dx="0.6604" dy="2.032" layer="1"/>
<smd name="7" x="3.175" y="-3.0734" dx="0.6604" dy="2.032" layer="1"/>
<smd name="11" x="1.905" y="3.0734" dx="0.6604" dy="2.032" layer="1"/>
<smd name="10" x="3.175" y="3.0734" dx="0.6604" dy="2.032" layer="1"/>
<smd name="8" x="4.445" y="-3.0734" dx="0.6604" dy="2.032" layer="1"/>
<smd name="9" x="4.445" y="3.0734" dx="0.6604" dy="2.032" layer="1"/>
<text x="-3.81" y="-0.762" size="1.27" layer="27" ratio="10">&gt;VALUE</text>
<text x="-5.461" y="-1.905" size="1.27" layer="25" ratio="10" rot="R90">&gt;NAME</text>
<rectangle x1="-0.889" y1="1.9558" x2="-0.381" y2="3.0988" layer="51"/>
<rectangle x1="-4.699" y1="-3.0988" x2="-4.191" y2="-1.9558" layer="51"/>
<rectangle x1="-3.429" y1="-3.0988" x2="-2.921" y2="-1.9558" layer="51"/>
<rectangle x1="-2.159" y1="-3.0734" x2="-1.651" y2="-1.9304" layer="51"/>
<rectangle x1="-0.889" y1="-3.0988" x2="-0.381" y2="-1.9558" layer="51"/>
<rectangle x1="-2.159" y1="1.9558" x2="-1.651" y2="3.0988" layer="51"/>
<rectangle x1="-3.429" y1="1.9558" x2="-2.921" y2="3.0988" layer="51"/>
<rectangle x1="-4.699" y1="1.9558" x2="-4.191" y2="3.0988" layer="51"/>
<rectangle x1="0.381" y1="-3.0988" x2="0.889" y2="-1.9558" layer="51"/>
<rectangle x1="1.651" y1="-3.0988" x2="2.159" y2="-1.9558" layer="51"/>
<rectangle x1="2.921" y1="-3.0988" x2="3.429" y2="-1.9558" layer="51"/>
<rectangle x1="4.191" y1="-3.0988" x2="4.699" y2="-1.9558" layer="51"/>
<rectangle x1="0.381" y1="1.9558" x2="0.889" y2="3.0988" layer="51"/>
<rectangle x1="1.651" y1="1.9558" x2="2.159" y2="3.0988" layer="51"/>
<rectangle x1="2.921" y1="1.9558" x2="3.429" y2="3.0988" layer="51"/>
<rectangle x1="4.191" y1="1.9558" x2="4.699" y2="3.0988" layer="51"/>
</package>
<package name="DIL14">
<description>&lt;b&gt;Dual In Line Package&lt;/b&gt;</description>
<wire x1="8.89" y1="2.921" x2="-8.89" y2="2.921" width="0.1524" layer="21"/>
<wire x1="-8.89" y1="-2.921" x2="8.89" y2="-2.921" width="0.1524" layer="21"/>
<wire x1="8.89" y1="2.921" x2="8.89" y2="-2.921" width="0.1524" layer="21"/>
<wire x1="-8.89" y1="2.921" x2="-8.89" y2="1.016" width="0.1524" layer="21"/>
<wire x1="-8.89" y1="-2.921" x2="-8.89" y2="-1.016" width="0.1524" layer="21"/>
<wire x1="-8.89" y1="1.016" x2="-8.89" y2="-1.016" width="0.1524" layer="21" curve="-180"/>
<pad name="1" x="-7.62" y="-3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="2" x="-5.08" y="-3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="7" x="7.62" y="-3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="8" x="7.62" y="3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="3" x="-2.54" y="-3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="4" x="0" y="-3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="6" x="5.08" y="-3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="5" x="2.54" y="-3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="9" x="5.08" y="3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="10" x="2.54" y="3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="11" x="0" y="3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="12" x="-2.54" y="3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="13" x="-5.08" y="3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="14" x="-7.62" y="3.81" drill="0.8128" shape="long" rot="R90"/>
<text x="-9.271" y="-3.048" size="1.27" layer="25" ratio="10" rot="R90">&gt;NAME</text>
<text x="-6.731" y="-0.635" size="1.27" layer="27" ratio="10">&gt;VALUE</text>
</package>
<package name="SO14">
<description>&lt;b&gt;Small Outline package&lt;/b&gt; 150 mil</description>
<wire x1="4.064" y1="1.9558" x2="-4.064" y2="1.9558" width="0.1524" layer="51"/>
<wire x1="4.064" y1="-1.9558" x2="4.445" y2="-1.5748" width="0.1524" layer="21" curve="90"/>
<wire x1="-4.445" y1="1.5748" x2="-4.064" y2="1.9558" width="0.1524" layer="21" curve="-90"/>
<wire x1="4.064" y1="1.9558" x2="4.445" y2="1.5748" width="0.1524" layer="21" curve="-90"/>
<wire x1="-4.445" y1="-1.5748" x2="-4.064" y2="-1.9558" width="0.1524" layer="21" curve="90"/>
<wire x1="-4.064" y1="-1.9558" x2="4.064" y2="-1.9558" width="0.1524" layer="51"/>
<wire x1="4.445" y1="-1.5748" x2="4.445" y2="1.5748" width="0.1524" layer="21"/>
<wire x1="-4.445" y1="1.5748" x2="-4.445" y2="0.508" width="0.1524" layer="21"/>
<wire x1="-4.445" y1="0.508" x2="-4.445" y2="-0.508" width="0.1524" layer="21"/>
<wire x1="-4.445" y1="-0.508" x2="-4.445" y2="-1.5748" width="0.1524" layer="21"/>
<wire x1="-4.445" y1="0.508" x2="-4.445" y2="-0.508" width="0.1524" layer="21" curve="-180"/>
<wire x1="-4.445" y1="-1.6002" x2="4.445" y2="-1.6002" width="0.0508" layer="21"/>
<smd name="1" x="-3.81" y="-3.0734" dx="0.6604" dy="2.032" layer="1"/>
<smd name="14" x="-3.81" y="3.0734" dx="0.6604" dy="2.032" layer="1"/>
<smd name="2" x="-2.54" y="-3.0734" dx="0.6604" dy="2.032" layer="1"/>
<smd name="3" x="-1.27" y="-3.0734" dx="0.6604" dy="2.032" layer="1"/>
<smd name="13" x="-2.54" y="3.0734" dx="0.6604" dy="2.032" layer="1"/>
<smd name="12" x="-1.27" y="3.0734" dx="0.6604" dy="2.032" layer="1"/>
<smd name="4" x="0" y="-3.0734" dx="0.6604" dy="2.032" layer="1"/>
<smd name="11" x="0" y="3.0734" dx="0.6604" dy="2.032" layer="1"/>
<smd name="5" x="1.27" y="-3.0734" dx="0.6604" dy="2.032" layer="1"/>
<smd name="6" x="2.54" y="-3.0734" dx="0.6604" dy="2.032" layer="1"/>
<smd name="10" x="1.27" y="3.0734" dx="0.6604" dy="2.032" layer="1"/>
<smd name="9" x="2.54" y="3.0734" dx="0.6604" dy="2.032" layer="1"/>
<smd name="7" x="3.81" y="-3.0734" dx="0.6604" dy="2.032" layer="1"/>
<smd name="8" x="3.81" y="3.0734" dx="0.6604" dy="2.032" layer="1"/>
<text x="-3.175" y="-0.762" size="1.27" layer="27" ratio="10">&gt;VALUE</text>
<text x="-4.826" y="-1.905" size="1.27" layer="25" ratio="10" rot="R90">&gt;NAME</text>
<rectangle x1="-0.254" y1="1.9558" x2="0.254" y2="3.0988" layer="51"/>
<rectangle x1="-4.064" y1="-3.0988" x2="-3.556" y2="-1.9558" layer="51"/>
<rectangle x1="-2.794" y1="-3.0988" x2="-2.286" y2="-1.9558" layer="51"/>
<rectangle x1="-1.524" y1="-3.0734" x2="-1.016" y2="-1.9304" layer="51"/>
<rectangle x1="-0.254" y1="-3.0988" x2="0.254" y2="-1.9558" layer="51"/>
<rectangle x1="-1.524" y1="1.9558" x2="-1.016" y2="3.0988" layer="51"/>
<rectangle x1="-2.794" y1="1.9558" x2="-2.286" y2="3.0988" layer="51"/>
<rectangle x1="-4.064" y1="1.9558" x2="-3.556" y2="3.0988" layer="51"/>
<rectangle x1="1.016" y1="1.9558" x2="1.524" y2="3.0988" layer="51"/>
<rectangle x1="2.286" y1="1.9558" x2="2.794" y2="3.0988" layer="51"/>
<rectangle x1="3.556" y1="1.9558" x2="4.064" y2="3.0988" layer="51"/>
<rectangle x1="1.016" y1="-3.0988" x2="1.524" y2="-1.9558" layer="51"/>
<rectangle x1="2.286" y1="-3.0988" x2="2.794" y2="-1.9558" layer="51"/>
<rectangle x1="3.556" y1="-3.0988" x2="4.064" y2="-1.9558" layer="51"/>
</package>
<package name="LCC20">
<description>&lt;b&gt;Leadless Chip Carrier&lt;/b&gt;&lt;p&gt; Ceramic Package</description>
<wire x1="-0.4001" y1="4.4" x2="-0.87" y2="4.4" width="0.2032" layer="51"/>
<wire x1="-3.3" y1="4.4" x2="-4.4" y2="3.3" width="0.2032" layer="51"/>
<wire x1="-0.4001" y1="4.3985" x2="0.4001" y2="4.3985" width="0.2032" layer="51" curve="180"/>
<wire x1="-1.6701" y1="4.3985" x2="-0.8699" y2="4.3985" width="0.2032" layer="51" curve="180"/>
<wire x1="-4.3985" y1="2.14" x2="-4.3985" y2="2.94" width="0.2032" layer="51" curve="180"/>
<wire x1="-2.9401" y1="4.4" x2="-3.3" y2="4.4" width="0.2032" layer="51"/>
<wire x1="0.87" y1="4.4" x2="0.4001" y2="4.4" width="0.2032" layer="51"/>
<wire x1="0.87" y1="4.3985" x2="1.67" y2="4.3985" width="0.2032" layer="51" curve="180"/>
<wire x1="-4.4" y1="3.3" x2="-4.4" y2="2.9401" width="0.2032" layer="51"/>
<wire x1="-4.4" y1="2.14" x2="-4.4" y2="1.6701" width="0.2032" layer="51"/>
<wire x1="-4.3985" y1="0.87" x2="-4.3985" y2="1.67" width="0.2032" layer="51" curve="180"/>
<wire x1="-4.3985" y1="-0.4001" x2="-4.3985" y2="0.4001" width="0.2032" layer="51" curve="180"/>
<wire x1="-4.3985" y1="-1.6701" x2="-4.3985" y2="-0.8699" width="0.2032" layer="51" curve="180"/>
<wire x1="-4.4" y1="0.87" x2="-4.4" y2="0.4001" width="0.2032" layer="51"/>
<wire x1="-4.4" y1="-0.4001" x2="-4.4" y2="-0.87" width="0.2032" layer="51"/>
<wire x1="-4.4" y1="-2.9401" x2="-4.4" y2="-4.4" width="0.2032" layer="51"/>
<wire x1="-4.4" y1="-4.4" x2="-4.4" y2="-4.4099" width="0.2032" layer="51"/>
<wire x1="2.14" y1="4.3985" x2="2.94" y2="4.3985" width="0.2032" layer="51" curve="180"/>
<wire x1="2.14" y1="4.4" x2="1.6701" y2="4.4" width="0.2032" layer="51"/>
<wire x1="4.4" y1="4.4" x2="2.9401" y2="4.4" width="0.2032" layer="51"/>
<wire x1="0.4001" y1="-4.4" x2="0.87" y2="-4.4" width="0.2032" layer="51"/>
<wire x1="-0.4001" y1="-4.3985" x2="0.4001" y2="-4.3985" width="0.2032" layer="51" curve="-180"/>
<wire x1="0.87" y1="-4.3985" x2="1.67" y2="-4.3985" width="0.2032" layer="51" curve="-180"/>
<wire x1="2.9401" y1="-4.4" x2="4.4" y2="-4.4" width="0.2032" layer="51"/>
<wire x1="-0.87" y1="-4.4" x2="-0.4001" y2="-4.4" width="0.2032" layer="51"/>
<wire x1="-1.6701" y1="-4.3985" x2="-0.8699" y2="-4.3985" width="0.2032" layer="51" curve="-180"/>
<wire x1="-2.9401" y1="-4.3985" x2="-2.1399" y2="-4.3985" width="0.2032" layer="51" curve="-180"/>
<wire x1="-2.14" y1="-4.4" x2="-1.6701" y2="-4.4" width="0.2032" layer="51"/>
<wire x1="-4.4" y1="-4.4" x2="-2.9401" y2="-4.4" width="0.2032" layer="51"/>
<wire x1="4.4" y1="0.4001" x2="4.4" y2="0.87" width="0.2032" layer="51"/>
<wire x1="4.3985" y1="0.4001" x2="4.3985" y2="-0.4001" width="0.2032" layer="51" curve="180"/>
<wire x1="4.3985" y1="1.6701" x2="4.3985" y2="0.8699" width="0.2032" layer="51" curve="180"/>
<wire x1="4.4" y1="2.9401" x2="4.4" y2="4.4" width="0.2032" layer="51"/>
<wire x1="4.4" y1="-0.87" x2="4.4" y2="-0.4001" width="0.2032" layer="51"/>
<wire x1="4.3985" y1="-0.87" x2="4.3985" y2="-1.67" width="0.2032" layer="51" curve="180"/>
<wire x1="4.3985" y1="-2.14" x2="4.3985" y2="-2.94" width="0.2032" layer="51" curve="180"/>
<wire x1="4.4" y1="-2.14" x2="4.4" y2="-1.6701" width="0.2032" layer="51"/>
<wire x1="4.4" y1="-4.4" x2="4.4" y2="-2.9401" width="0.2032" layer="51"/>
<wire x1="-2.9401" y1="4.3985" x2="-2.1399" y2="4.3985" width="0.2032" layer="51" curve="180"/>
<wire x1="-1.6701" y1="4.4" x2="-2.14" y2="4.4" width="0.2032" layer="51"/>
<wire x1="-4.3985" y1="-2.9401" x2="-4.3985" y2="-2.1399" width="0.2032" layer="51" curve="180"/>
<wire x1="-4.4" y1="-1.6701" x2="-4.4" y2="-2.14" width="0.2032" layer="51"/>
<wire x1="1.6701" y1="-4.4" x2="2.14" y2="-4.4" width="0.2032" layer="51"/>
<wire x1="2.14" y1="-4.3985" x2="2.94" y2="-4.3985" width="0.2032" layer="51" curve="-180"/>
<wire x1="4.3985" y1="2.9401" x2="4.3985" y2="2.1399" width="0.2032" layer="51" curve="180"/>
<wire x1="4.4" y1="1.6701" x2="4.4" y2="2.14" width="0.2032" layer="51"/>
<wire x1="-3.3" y1="4.4" x2="-4.4" y2="3.3" width="0.2032" layer="21"/>
<wire x1="-4.4" y1="-3.1941" x2="-4.4" y2="-4.4" width="0.2032" layer="21"/>
<wire x1="-4.4" y1="-4.4" x2="-3.1941" y2="-4.4" width="0.2032" layer="21"/>
<wire x1="3.1941" y1="-4.4" x2="4.4" y2="-4.4" width="0.2032" layer="21"/>
<wire x1="4.4" y1="-4.4" x2="4.4" y2="-3.1941" width="0.2032" layer="21"/>
<wire x1="4.4" y1="3.1941" x2="4.4" y2="4.4" width="0.2032" layer="21"/>
<wire x1="4.4" y1="4.4" x2="3.1941" y2="4.4" width="0.2032" layer="21"/>
<smd name="2" x="-1.27" y="4.5001" dx="0.8" dy="2" layer="1"/>
<smd name="1" x="0" y="3.8001" dx="0.8" dy="3.4" layer="1"/>
<smd name="3" x="-2.54" y="4.5001" dx="0.8" dy="2" layer="1"/>
<smd name="4" x="-4.5001" y="2.54" dx="2" dy="0.8" layer="1"/>
<smd name="5" x="-4.5001" y="1.27" dx="2" dy="0.8" layer="1"/>
<smd name="6" x="-4.5001" y="0" dx="2" dy="0.8" layer="1"/>
<smd name="7" x="-4.5001" y="-1.27" dx="2" dy="0.8" layer="1"/>
<smd name="8" x="-4.5001" y="-2.54" dx="2" dy="0.8" layer="1"/>
<smd name="9" x="-2.54" y="-4.5001" dx="0.8" dy="2" layer="1"/>
<smd name="10" x="-1.27" y="-4.5001" dx="0.8" dy="2" layer="1"/>
<smd name="11" x="0" y="-4.5001" dx="0.8" dy="2" layer="1"/>
<smd name="12" x="1.27" y="-4.5001" dx="0.8" dy="2" layer="1"/>
<smd name="13" x="2.54" y="-4.5001" dx="0.8" dy="2" layer="1"/>
<smd name="14" x="4.5001" y="-2.54" dx="2" dy="0.8" layer="1"/>
<smd name="15" x="4.5001" y="-1.27" dx="2" dy="0.8" layer="1"/>
<smd name="16" x="4.5001" y="0" dx="2" dy="0.8" layer="1"/>
<smd name="17" x="4.5001" y="1.27" dx="2" dy="0.8" layer="1"/>
<smd name="18" x="4.5001" y="2.54" dx="2" dy="0.8" layer="1"/>
<smd name="19" x="2.54" y="4.5001" dx="0.8" dy="2" layer="1"/>
<smd name="20" x="1.27" y="4.5001" dx="0.8" dy="2" layer="1"/>
<text x="-4.0051" y="6.065" size="1.778" layer="25">&gt;NAME</text>
<text x="-3.9751" y="-7.5601" size="1.778" layer="27">&gt;VALUE</text>
</package>
</packages>
<symbols>
<symbol name="7496">
<wire x1="-7.62" y1="-15.24" x2="7.62" y2="-15.24" width="0.4064" layer="94"/>
<wire x1="7.62" y1="-15.24" x2="7.62" y2="12.7" width="0.4064" layer="94"/>
<wire x1="7.62" y1="12.7" x2="-7.62" y2="12.7" width="0.4064" layer="94"/>
<wire x1="-7.62" y1="12.7" x2="-7.62" y2="-15.24" width="0.4064" layer="94"/>
<text x="-7.62" y="13.335" size="1.778" layer="95">&gt;NAME</text>
<text x="-7.62" y="-17.78" size="1.778" layer="96">&gt;VALUE</text>
<pin name="CLK" x="-12.7" y="-7.62" length="middle" direction="in" function="clk"/>
<pin name="A" x="-12.7" y="7.62" length="middle" direction="in"/>
<pin name="B" x="-12.7" y="5.08" length="middle" direction="in"/>
<pin name="C" x="-12.7" y="2.54" length="middle" direction="in"/>
<pin name="D" x="-12.7" y="0" length="middle" direction="in"/>
<pin name="E" x="-12.7" y="-2.54" length="middle" direction="in"/>
<pin name="PE" x="-12.7" y="-10.16" length="middle" direction="in"/>
<pin name="SER" x="-12.7" y="10.16" length="middle" direction="in"/>
<pin name="QE" x="12.7" y="-2.54" length="middle" direction="out" rot="R180"/>
<pin name="QD" x="12.7" y="0" length="middle" direction="out" rot="R180"/>
<pin name="QC" x="12.7" y="2.54" length="middle" direction="out" rot="R180"/>
<pin name="QB" x="12.7" y="5.08" length="middle" direction="out" rot="R180"/>
<pin name="QA" x="12.7" y="7.62" length="middle" direction="out" rot="R180"/>
<pin name="CLR" x="-12.7" y="-12.7" length="middle" direction="in" function="dot"/>
</symbol>
<symbol name="PWRN">
<text x="-0.635" y="-0.635" size="1.778" layer="95">&gt;NAME</text>
<text x="1.905" y="-5.842" size="1.27" layer="95" rot="R90">GND</text>
<text x="1.905" y="2.54" size="1.27" layer="95" rot="R90">VCC</text>
<pin name="GND" x="0" y="-7.62" visible="pad" length="middle" direction="pwr" rot="R90"/>
<pin name="VCC" x="0" y="7.62" visible="pad" length="middle" direction="pwr" rot="R270"/>
</symbol>
<symbol name="7493">
<wire x1="-7.62" y1="-7.62" x2="7.62" y2="-7.62" width="0.4064" layer="94"/>
<wire x1="7.62" y1="-7.62" x2="7.62" y2="7.62" width="0.4064" layer="94"/>
<wire x1="7.62" y1="7.62" x2="-7.62" y2="7.62" width="0.4064" layer="94"/>
<wire x1="-7.62" y1="7.62" x2="-7.62" y2="-7.62" width="0.4064" layer="94"/>
<text x="-7.62" y="8.255" size="1.778" layer="95">&gt;NAME</text>
<text x="-7.62" y="-10.16" size="1.778" layer="96">&gt;VALUE</text>
<pin name="CKB" x="-12.7" y="2.54" length="middle" direction="in" function="clk"/>
<pin name="R0(1)" x="-12.7" y="-2.54" length="middle" direction="in"/>
<pin name="R0(2)" x="-12.7" y="-5.08" length="middle" direction="in"/>
<pin name="QC" x="12.7" y="0" length="middle" direction="out" rot="R180"/>
<pin name="QB" x="12.7" y="2.54" length="middle" direction="out" rot="R180"/>
<pin name="QD" x="12.7" y="-2.54" length="middle" direction="out" rot="R180"/>
<pin name="QA" x="12.7" y="5.08" length="middle" direction="out" rot="R180"/>
<pin name="CKA" x="-12.7" y="5.08" length="middle" direction="in" function="clk"/>
</symbol>
<symbol name="7474">
<wire x1="-7.62" y1="-7.62" x2="7.62" y2="-7.62" width="0.4064" layer="94"/>
<wire x1="7.62" y1="-7.62" x2="7.62" y2="7.62" width="0.4064" layer="94"/>
<wire x1="7.62" y1="7.62" x2="-7.62" y2="7.62" width="0.4064" layer="94"/>
<wire x1="-7.62" y1="7.62" x2="-7.62" y2="-7.62" width="0.4064" layer="94"/>
<text x="-7.62" y="8.255" size="1.778" layer="95">&gt;NAME</text>
<text x="-7.62" y="-10.16" size="1.778" layer="96">&gt;VALUE</text>
<pin name="CLR" x="-12.7" y="-5.08" length="middle" direction="in" function="dot"/>
<pin name="D" x="-12.7" y="2.54" length="middle" direction="in"/>
<pin name="CLK" x="-12.7" y="-2.54" length="middle" direction="in" function="clk"/>
<pin name="PRE" x="-12.7" y="5.08" length="middle" direction="in" function="dot"/>
<pin name="Q" x="12.7" y="5.08" length="middle" direction="out" rot="R180"/>
<pin name="!Q" x="12.7" y="-5.08" length="middle" direction="out" rot="R180"/>
</symbol>
</symbols>
<devicesets>
<deviceset name="74*96" prefix="IC">
<description>5-bit &lt;b&gt;SHIFT REGISTER&lt;/b&gt;</description>
<gates>
<gate name="A" symbol="7496" x="20.32" y="0"/>
<gate name="P" symbol="PWRN" x="-5.08" y="0" addlevel="request"/>
</gates>
<devices>
<device name="N" package="DIL16">
<connects>
<connect gate="A" pin="A" pad="2"/>
<connect gate="A" pin="B" pad="3"/>
<connect gate="A" pin="C" pad="4"/>
<connect gate="A" pin="CLK" pad="1"/>
<connect gate="A" pin="CLR" pad="16"/>
<connect gate="A" pin="D" pad="6"/>
<connect gate="A" pin="E" pad="7"/>
<connect gate="A" pin="PE" pad="8"/>
<connect gate="A" pin="QA" pad="15"/>
<connect gate="A" pin="QB" pad="14"/>
<connect gate="A" pin="QC" pad="13"/>
<connect gate="A" pin="QD" pad="11"/>
<connect gate="A" pin="QE" pad="10"/>
<connect gate="A" pin="SER" pad="9"/>
<connect gate="P" pin="GND" pad="12"/>
<connect gate="P" pin="VCC" pad="5"/>
</connects>
<technologies>
<technology name="LS"/>
</technologies>
</device>
<device name="D" package="SO16">
<connects>
<connect gate="A" pin="A" pad="2"/>
<connect gate="A" pin="B" pad="3"/>
<connect gate="A" pin="C" pad="4"/>
<connect gate="A" pin="CLK" pad="1"/>
<connect gate="A" pin="CLR" pad="16"/>
<connect gate="A" pin="D" pad="6"/>
<connect gate="A" pin="E" pad="7"/>
<connect gate="A" pin="PE" pad="8"/>
<connect gate="A" pin="QA" pad="15"/>
<connect gate="A" pin="QB" pad="14"/>
<connect gate="A" pin="QC" pad="13"/>
<connect gate="A" pin="QD" pad="11"/>
<connect gate="A" pin="QE" pad="10"/>
<connect gate="A" pin="SER" pad="9"/>
<connect gate="P" pin="GND" pad="12"/>
<connect gate="P" pin="VCC" pad="5"/>
</connects>
<technologies>
<technology name="LS"/>
</technologies>
</device>
</devices>
</deviceset>
<deviceset name="74*93" prefix="IC">
<description>Decade, divide by twelve and binary &lt;b&gt;COUNTER&lt;/b&gt;</description>
<gates>
<gate name="A" symbol="7493" x="20.32" y="0"/>
<gate name="P" symbol="PWRN" x="-5.08" y="0" addlevel="request"/>
</gates>
<devices>
<device name="N" package="DIL14">
<connects>
<connect gate="A" pin="CKA" pad="14"/>
<connect gate="A" pin="CKB" pad="1"/>
<connect gate="A" pin="QA" pad="12"/>
<connect gate="A" pin="QB" pad="9"/>
<connect gate="A" pin="QC" pad="8"/>
<connect gate="A" pin="QD" pad="11"/>
<connect gate="A" pin="R0(1)" pad="2"/>
<connect gate="A" pin="R0(2)" pad="3"/>
<connect gate="P" pin="GND" pad="10"/>
<connect gate="P" pin="VCC" pad="5"/>
</connects>
<technologies>
<technology name="HC"/>
<technology name="HCT"/>
<technology name="LS"/>
</technologies>
</device>
<device name="D" package="SO14">
<connects>
<connect gate="A" pin="CKA" pad="14"/>
<connect gate="A" pin="CKB" pad="1"/>
<connect gate="A" pin="QA" pad="12"/>
<connect gate="A" pin="QB" pad="9"/>
<connect gate="A" pin="QC" pad="8"/>
<connect gate="A" pin="QD" pad="11"/>
<connect gate="A" pin="R0(1)" pad="2"/>
<connect gate="A" pin="R0(2)" pad="3"/>
<connect gate="P" pin="GND" pad="10"/>
<connect gate="P" pin="VCC" pad="5"/>
</connects>
<technologies>
<technology name="HC"/>
<technology name="HCT"/>
<technology name="LS"/>
</technologies>
</device>
</devices>
</deviceset>
<deviceset name="74*74" prefix="IC">
<description>Dual D type positive edge triggered &lt;b&gt;FLIP FLOP&lt;/b&gt;, preset and clear</description>
<gates>
<gate name="A" symbol="7474" x="20.32" y="0" swaplevel="1"/>
<gate name="B" symbol="7474" x="20.32" y="-22.86" swaplevel="1"/>
<gate name="P" symbol="PWRN" x="-5.08" y="0" addlevel="request"/>
</gates>
<devices>
<device name="N" package="DIL14">
<connects>
<connect gate="A" pin="!Q" pad="6"/>
<connect gate="A" pin="CLK" pad="3"/>
<connect gate="A" pin="CLR" pad="1"/>
<connect gate="A" pin="D" pad="2"/>
<connect gate="A" pin="PRE" pad="4"/>
<connect gate="A" pin="Q" pad="5"/>
<connect gate="B" pin="!Q" pad="8"/>
<connect gate="B" pin="CLK" pad="11"/>
<connect gate="B" pin="CLR" pad="13"/>
<connect gate="B" pin="D" pad="12"/>
<connect gate="B" pin="PRE" pad="10"/>
<connect gate="B" pin="Q" pad="9"/>
<connect gate="P" pin="GND" pad="7"/>
<connect gate="P" pin="VCC" pad="14"/>
</connects>
<technologies>
<technology name="AC"/>
<technology name="ACT"/>
<technology name="HC"/>
<technology name="HCT"/>
<technology name="LS"/>
<technology name="S"/>
</technologies>
</device>
<device name="D" package="SO14">
<connects>
<connect gate="A" pin="!Q" pad="6"/>
<connect gate="A" pin="CLK" pad="3"/>
<connect gate="A" pin="CLR" pad="1"/>
<connect gate="A" pin="D" pad="2"/>
<connect gate="A" pin="PRE" pad="4"/>
<connect gate="A" pin="Q" pad="5"/>
<connect gate="B" pin="!Q" pad="8"/>
<connect gate="B" pin="CLK" pad="11"/>
<connect gate="B" pin="CLR" pad="13"/>
<connect gate="B" pin="D" pad="12"/>
<connect gate="B" pin="PRE" pad="10"/>
<connect gate="B" pin="Q" pad="9"/>
<connect gate="P" pin="GND" pad="7"/>
<connect gate="P" pin="VCC" pad="14"/>
</connects>
<technologies>
<technology name="AC"/>
<technology name="ACT"/>
<technology name="HC"/>
<technology name="HCT"/>
<technology name="LS"/>
<technology name="S"/>
</technologies>
</device>
<device name="FK" package="LCC20">
<connects>
<connect gate="A" pin="!Q" pad="9"/>
<connect gate="A" pin="CLK" pad="4"/>
<connect gate="A" pin="CLR" pad="2"/>
<connect gate="A" pin="D" pad="3"/>
<connect gate="A" pin="PRE" pad="6"/>
<connect gate="A" pin="Q" pad="8"/>
<connect gate="B" pin="!Q" pad="12"/>
<connect gate="B" pin="CLK" pad="16"/>
<connect gate="B" pin="CLR" pad="19"/>
<connect gate="B" pin="D" pad="18"/>
<connect gate="B" pin="PRE" pad="14"/>
<connect gate="B" pin="Q" pad="13"/>
<connect gate="P" pin="GND" pad="10"/>
<connect gate="P" pin="VCC" pad="20"/>
</connects>
<technologies>
<technology name="AC"/>
<technology name="ACT"/>
<technology name="HC"/>
<technology name="HCT"/>
<technology name="LS"/>
<technology name="S"/>
</technologies>
</device>
</devices>
</deviceset>
</devicesets>
</library>
<library name="switch-dil">
<description>&lt;b&gt;DIL Switches and Code Switches&lt;/b&gt;&lt;p&gt;
&lt;author&gt;Created by librarian@cadsoft.de&lt;/author&gt;</description>
<packages>
<package name="DS-01">
<description>&lt;b&gt;DIL/CODE SWITCH&lt;/b&gt;&lt;p&gt;
Mors</description>
<wire x1="-2.032" y1="-5.08" x2="2.032" y2="-5.08" width="0.1524" layer="21"/>
<wire x1="2.032" y1="5.08" x2="-2.032" y2="5.08" width="0.1524" layer="21"/>
<wire x1="-2.032" y1="5.08" x2="-2.032" y2="1.905" width="0.1524" layer="21"/>
<wire x1="-2.032" y1="1.905" x2="-2.032" y2="-1.905" width="0.1524" layer="21"/>
<wire x1="-2.032" y1="-1.905" x2="-2.032" y2="-5.08" width="0.1524" layer="21"/>
<wire x1="2.032" y1="-5.08" x2="2.032" y2="5.08" width="0.1524" layer="21"/>
<wire x1="-0.762" y1="1.905" x2="-0.762" y2="-1.905" width="0.1524" layer="21"/>
<wire x1="-0.762" y1="1.905" x2="0.762" y2="1.905" width="0.1524" layer="21"/>
<wire x1="0.762" y1="-1.905" x2="0.762" y2="1.905" width="0.1524" layer="21"/>
<wire x1="0.762" y1="-1.905" x2="-0.762" y2="-1.905" width="0.1524" layer="21"/>
<wire x1="-2.032" y1="1.905" x2="-1.397" y2="1.905" width="0.1524" layer="21"/>
<wire x1="-1.397" y1="-1.905" x2="-1.397" y2="1.905" width="0.1524" layer="21"/>
<wire x1="-2.032" y1="-1.905" x2="-1.397" y2="-1.905" width="0.1524" layer="21"/>
<pad name="1" x="0" y="-3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="2" x="0" y="3.81" drill="0.8128" shape="long" rot="R90"/>
<text x="-0.254" y="-3.429" size="0.9906" layer="51" ratio="14">1</text>
<text x="-2.032" y="-6.731" size="1.27" layer="27" ratio="10">&gt;VALUE</text>
<text x="-2.032" y="5.461" size="1.27" layer="25" ratio="10">&gt;NAME</text>
<text x="-0.762" y="2.413" size="0.9906" layer="51" ratio="14">ON</text>
<rectangle x1="-0.762" y1="-1.905" x2="0.762" y2="0" layer="21"/>
</package>
</packages>
<symbols>
<symbol name="S+V">
<wire x1="0" y1="-3.175" x2="0" y2="-1.905" width="0.254" layer="94"/>
<wire x1="0" y1="-1.905" x2="-1.27" y2="1.905" width="0.254" layer="94"/>
<wire x1="0" y1="1.905" x2="0" y2="3.175" width="0.254" layer="94"/>
<text x="2.54" y="-3.81" size="1.778" layer="95" rot="R90">&gt;NAME</text>
<text x="5.08" y="-3.81" size="1.778" layer="96" rot="R90">&gt;VALUE</text>
<pin name="1" x="0" y="-5.08" visible="pad" length="short" direction="pas" rot="R90"/>
<pin name="2" x="0" y="5.08" visible="pad" length="short" direction="pas" rot="R270"/>
</symbol>
</symbols>
<devicesets>
<deviceset name="DS01E" prefix="S" uservalue="yes">
<description>&lt;b&gt;DIL/CODE SWITCH&lt;/b&gt;</description>
<gates>
<gate name="1" symbol="S+V" x="0" y="0"/>
</gates>
<devices>
<device name="" package="DS-01">
<connects>
<connect gate="1" pin="1" pad="1"/>
<connect gate="1" pin="2" pad="2"/>
</connects>
<technologies>
<technology name="">
<attribute name="MF" value="" constant="no"/>
<attribute name="MPN" value="" constant="no"/>
<attribute name="OC_FARNELL" value="unknown" constant="no"/>
<attribute name="OC_NEWARK" value="unknown" constant="no"/>
</technology>
</technologies>
</device>
</devices>
</deviceset>
</devicesets>
</library>
<library name="supply2">
<description>&lt;b&gt;Supply Symbols&lt;/b&gt;&lt;p&gt;
GND, VCC, 0V, +5V, -5V, etc.&lt;p&gt;
Please keep in mind, that these devices are necessary for the
automatic wiring of the supply signals.&lt;p&gt;
The pin name defined in the symbol is identical to the net which is to be wired automatically.&lt;p&gt;
In this library the device names are the same as the pin names of the symbols, therefore the correct signal names appear next to the supply symbols in the schematic.&lt;p&gt;
&lt;author&gt;Created by librarian@cadsoft.de&lt;/author&gt;</description>
<packages>
</packages>
<symbols>
<symbol name="VCC">
<circle x="0" y="1.27" radius="1.27" width="0.254" layer="94"/>
<text x="-1.905" y="3.175" size="1.778" layer="96">&gt;VALUE</text>
<pin name="VCC" x="0" y="-2.54" visible="off" length="short" direction="sup" rot="R90"/>
</symbol>
</symbols>
<devicesets>
<deviceset name="VCC" prefix="SUPPLY">
<description>&lt;b&gt;SUPPLY SYMBOL&lt;/b&gt;</description>
<gates>
<gate name="G$1" symbol="VCC" x="0" y="0"/>
</gates>
<devices>
<device name="">
<technologies>
<technology name=""/>
</technologies>
</device>
</devices>
</deviceset>
</devicesets>
</library>
<library name="74ttl-din">
<description>&lt;b&gt;TTL Devices with DIN Symbols&lt;/b&gt;&lt;p&gt;
CadSoft and the author do not warrant that this library is free from error
or will meet your specific requirements.&lt;p&gt;
&lt;author&gt;Created by Holger Bettenb??hl, hol.bet.@rhein-main.net&lt;/author&gt;</description>
<packages>
<package name="DIL14">
<description>&lt;b&gt;Dual In Line Package&lt;/b&gt;</description>
<wire x1="8.89" y1="2.921" x2="-8.89" y2="2.921" width="0.1524" layer="21"/>
<wire x1="-8.89" y1="-2.921" x2="8.89" y2="-2.921" width="0.1524" layer="21"/>
<wire x1="8.89" y1="2.921" x2="8.89" y2="-2.921" width="0.1524" layer="21"/>
<wire x1="-8.89" y1="2.921" x2="-8.89" y2="1.016" width="0.1524" layer="21"/>
<wire x1="-8.89" y1="-2.921" x2="-8.89" y2="-1.016" width="0.1524" layer="21"/>
<wire x1="-8.89" y1="1.016" x2="-8.89" y2="-1.016" width="0.1524" layer="21" curve="-180"/>
<pad name="1" x="-7.62" y="-3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="2" x="-5.08" y="-3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="7" x="7.62" y="-3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="8" x="7.62" y="3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="3" x="-2.54" y="-3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="4" x="0" y="-3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="6" x="5.08" y="-3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="5" x="2.54" y="-3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="9" x="5.08" y="3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="10" x="2.54" y="3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="11" x="0" y="3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="12" x="-2.54" y="3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="13" x="-5.08" y="3.81" drill="0.8128" shape="long" rot="R90"/>
<pad name="14" x="-7.62" y="3.81" drill="0.8128" shape="long" rot="R90"/>
<text x="-9.271" y="-3.048" size="1.27" layer="25" ratio="10" rot="R90">&gt;NAME</text>
<text x="-6.731" y="-0.635" size="1.27" layer="27" ratio="10">&gt;VALUE</text>
</package>
</packages>
<symbols>
<symbol name="+UB">
<circle x="0" y="-0.635" radius="0.635" width="0.1524" layer="94"/>
<text x="1.27" y="-1.27" size="1.524" layer="95">&gt;NAME</text>
<pin name="+UB" x="0" y="2.54" visible="pad" length="short" direction="pwr" rot="R270"/>
</symbol>
<symbol name="-UB">
<wire x1="0" y1="-0.635" x2="0" y2="0.635" width="0" layer="94"/>
<wire x1="0.635" y1="0" x2="-0.635" y2="0" width="0" layer="94"/>
<circle x="0" y="0.635" radius="0.635" width="0.1524" layer="94"/>
<text x="1.27" y="0" size="1.524" layer="95">&gt;NAME</text>
<pin name="-UB" x="0" y="-2.54" visible="pad" length="short" direction="pwr" rot="R90"/>
</symbol>
<symbol name="00">
<wire x1="-0.635" y1="0" x2="0.635" y2="0" width="0" layer="94"/>
<wire x1="0" y1="0.635" x2="0" y2="-0.635" width="0" layer="94"/>
<wire x1="-5.08" y1="-5.08" x2="-5.08" y2="-2.54" width="0.254" layer="94"/>
<wire x1="5.08" y1="5.08" x2="-5.08" y2="5.08" width="0.254" layer="94"/>
<wire x1="5.08" y1="5.08" x2="5.08" y2="1.27" width="0.254" layer="94"/>
<wire x1="-5.08" y1="-5.08" x2="5.08" y2="-5.08" width="0.254" layer="94"/>
<wire x1="7.62" y1="0" x2="5.08" y2="1.27" width="0.1524" layer="94"/>
<wire x1="5.08" y1="1.27" x2="5.08" y2="0" width="0.254" layer="94"/>
<wire x1="5.08" y1="0" x2="7.62" y2="0" width="0.1524" layer="94"/>
<wire x1="5.08" y1="0" x2="5.08" y2="-5.08" width="0.254" layer="94"/>
<wire x1="-7.62" y1="2.54" x2="-5.08" y2="2.54" width="0.1524" layer="94"/>
<wire x1="-5.08" y1="2.54" x2="-5.08" y2="5.08" width="0.254" layer="94"/>
<wire x1="-7.62" y1="-2.54" x2="-5.08" y2="-2.54" width="0.1524" layer="94"/>
<wire x1="-5.08" y1="-2.54" x2="-5.08" y2="2.54" width="0.254" layer="94"/>
<text x="-5.08" y="5.715" size="2.032" layer="95">&gt;NAME</text>
<text x="-5.08" y="-8.255" size="2.032" layer="96">&gt;VALUE</text>
<text x="-0.635" y="1.905" size="2.032" layer="94">&amp;</text>
<pin name="A" x="-10.16" y="2.54" visible="pad" length="short" direction="in" swaplevel="1"/>
<pin name="B" x="-10.16" y="-2.54" visible="pad" length="short" direction="in" swaplevel="1"/>
<pin name="Y" x="10.16" y="0" visible="pad" length="short" direction="out" rot="R180"/>
</symbol>
</symbols>
<devicesets>
<deviceset name="74*00" prefix="V">
<description>Quad 2-input &lt;b&gt;NAND&lt;/b&gt; gate</description>
<gates>
<gate name="/+UB" symbol="+UB" x="15.24" y="12.7" addlevel="request"/>
<gate name="/-UB" symbol="-UB" x="15.24" y="5.08" addlevel="request"/>
<gate name="/1" symbol="00" x="0" y="0" swaplevel="1"/>
<gate name="/2" symbol="00" x="0" y="17.78" swaplevel="1"/>
<gate name="/3" symbol="00" x="-22.86" y="0" swaplevel="1"/>
<gate name="/4" symbol="00" x="-22.86" y="17.78" swaplevel="1"/>
</gates>
<devices>
<device name="N" package="DIL14">
<connects>
<connect gate="/+UB" pin="+UB" pad="14"/>
<connect gate="/-UB" pin="-UB" pad="7"/>
<connect gate="/1" pin="A" pad="1"/>
<connect gate="/1" pin="B" pad="2"/>
<connect gate="/1" pin="Y" pad="3"/>
<connect gate="/2" pin="A" pad="4"/>
<connect gate="/2" pin="B" pad="5"/>
<connect gate="/2" pin="Y" pad="6"/>
<connect gate="/3" pin="A" pad="9"/>
<connect gate="/3" pin="B" pad="10"/>
<connect gate="/3" pin="Y" pad="8"/>
<connect gate="/4" pin="A" pad="12"/>
<connect gate="/4" pin="B" pad="13"/>
<connect gate="/4" pin="Y" pad="11"/>
</connects>
<technologies>
<technology name=""/>
<technology name="HC"/>
<technology name="HCT"/>
<technology name="LS"/>
</technologies>
</device>
</devices>
</deviceset>
</devicesets>
</library>
</libraries>
<attributes>
</attributes>
<variantdefs>
</variantdefs>
<classes>
<class number="0" name="default" width="0" drill="0">
</class>
</classes>
<parts>
<part name="IO1" library="74xx-eu" deviceset="74*96" device="N" technology="LS"/>
<part name="IO2" library="74xx-eu" deviceset="74*96" device="N" technology="LS"/>
<part name="IO5" library="74xx-eu" deviceset="74*93" device="N" technology="LS"/>
<part name="IO3" library="74xx-eu" deviceset="74*74" device="N" technology="S"/>
<part name="IO4" library="74xx-eu" deviceset="74*74" device="N" technology="S"/>
<part name="S1" library="switch-dil" deviceset="DS01E" device=""/>
<part name="S2" library="switch-dil" deviceset="DS01E" device=""/>
<part name="S3" library="switch-dil" deviceset="DS01E" device=""/>
<part name="S4" library="switch-dil" deviceset="DS01E" device=""/>
<part name="S5" library="switch-dil" deviceset="DS01E" device=""/>
<part name="DB" library="switch-dil" deviceset="DS01E" device=""/>
<part name="SUPPLY1" library="supply2" deviceset="VCC" device="" value="A"/>
<part name="SUPPLY2" library="supply2" deviceset="VCC" device="" value="B"/>
<part name="SUPPLY3" library="supply2" deviceset="VCC" device="" value="C"/>
<part name="SUPPLY4" library="supply2" deviceset="VCC" device="" value="D"/>
<part name="SUPPLY5" library="supply2" deviceset="VCC" device="" value="log.0"/>
<part name="SUPPLY6" library="supply2" deviceset="VCC" device="" value="1"/>
<part name="SUPPLY7" library="supply2" deviceset="VCC" device="" value="2"/>
<part name="SUPPLY8" library="supply2" deviceset="VCC" device="" value="3"/>
<part name="SUPPLY9" library="supply2" deviceset="VCC" device="" value="4"/>
<part name="SUPPLY10" library="supply2" deviceset="VCC" device="" value="log.0"/>
<part name="SUPPLY11" library="supply2" deviceset="VCC" device="" value="5"/>
<part name="SUPPLY12" library="supply2" deviceset="VCC" device="" value="6"/>
<part name="SUPPLY13" library="supply2" deviceset="VCC" device="" value="7"/>
<part name="SUPPLY14" library="supply2" deviceset="VCC" device="" value="8"/>
<part name="SUPPLY15" library="supply2" deviceset="VCC" device="" value="A"/>
<part name="SUPPLY16" library="supply2" deviceset="VCC" device="" value="B"/>
<part name="SUPPLY17" library="supply2" deviceset="VCC" device="" value="C"/>
<part name="SUPPLY18" library="supply2" deviceset="VCC" device="" value="D"/>
<part name="SUPPLY19" library="supply2" deviceset="VCC" device="" value="log.1"/>
<part name="IO6" library="74ttl-din" deviceset="74*00" device="N"/>
</parts>
<sheets>
<sheet>
<plain>
<text x="7.62" y="104.14" size="1.778" layer="91">1. 7-segmentov?? displej</text>
<text x="175.26" y="104.14" size="1.778" layer="91">2. 7-segmentov?? displej</text>
<text x="-5.08" y="86.36" size="1.778" layer="91">Log. sp??na??e</text>
<text x="-5.08" y="43.18" size="1.778" layer="91">Debounced tla????tko</text>
<text x="73.66" y="104.14" size="1.778" layer="91">LED 1-4</text>
<text x="124.46" y="104.14" size="1.778" layer="91">LED 5-8</text>
</plain>
<instances>
<instance part="IO1" gate="A" x="58.42" y="73.66" smashed="yes">
<attribute name="NAME" x="50.8" y="86.995" size="1.778" layer="95"/>
<attribute name="VALUE" x="50.8" y="55.88" size="1.778" layer="96"/>
</instance>
<instance part="IO2" gate="A" x="111.76" y="73.66" smashed="yes">
<attribute name="NAME" x="104.14" y="86.995" size="1.778" layer="95"/>
<attribute name="VALUE" x="104.14" y="55.88" size="1.778" layer="96"/>
</instance>
<instance part="IO5" gate="A" x="58.42" y="33.02" smashed="yes">
<attribute name="NAME" x="50.8" y="41.275" size="1.778" layer="95"/>
<attribute name="VALUE" x="50.8" y="22.86" size="1.778" layer="96"/>
</instance>
<instance part="IO3" gate="A" x="165.1" y="78.74" smashed="yes">
<attribute name="NAME" x="157.48" y="86.995" size="1.778" layer="95"/>
<attribute name="VALUE" x="157.48" y="68.58" size="1.778" layer="96"/>
</instance>
<instance part="IO3" gate="B" x="165.1" y="55.88" smashed="yes">
<attribute name="NAME" x="157.48" y="64.135" size="1.778" layer="95"/>
<attribute name="VALUE" x="157.48" y="45.72" size="1.778" layer="96"/>
</instance>
<instance part="IO4" gate="A" x="165.1" y="33.02" smashed="yes">
<attribute name="NAME" x="157.48" y="41.275" size="1.778" layer="95"/>
<attribute name="VALUE" x="157.48" y="22.86" size="1.778" layer="96"/>
</instance>
<instance part="IO4" gate="B" x="165.1" y="10.16" smashed="yes">
<attribute name="NAME" x="157.48" y="18.415" size="1.778" layer="95"/>
<attribute name="VALUE" x="157.48" y="0" size="1.778" layer="96"/>
</instance>
<instance part="S1" gate="1" x="2.54" y="81.28" smashed="yes" rot="R270">
<attribute name="NAME" x="-1.27" y="78.74" size="1.778" layer="95"/>
<attribute name="VALUE" x="-1.27" y="76.2" size="1.778" layer="96"/>
</instance>
<instance part="S2" gate="1" x="2.54" y="73.66" smashed="yes" rot="R270">
<attribute name="NAME" x="-1.27" y="71.12" size="1.778" layer="95"/>
<attribute name="VALUE" x="-1.27" y="68.58" size="1.778" layer="96"/>
</instance>
<instance part="S3" gate="1" x="2.54" y="66.04" smashed="yes" rot="R270">
<attribute name="NAME" x="-1.27" y="63.5" size="1.778" layer="95"/>
<attribute name="VALUE" x="-1.27" y="60.96" size="1.778" layer="96"/>
</instance>
<instance part="S4" gate="1" x="2.54" y="58.42" smashed="yes" rot="R270">
<attribute name="NAME" x="-1.27" y="55.88" size="1.778" layer="95"/>
<attribute name="VALUE" x="-1.27" y="53.34" size="1.778" layer="96"/>
</instance>
<instance part="S5" gate="1" x="2.54" y="50.8" smashed="yes" rot="R270">
<attribute name="NAME" x="-1.27" y="48.26" size="1.778" layer="95"/>
<attribute name="VALUE" x="-1.27" y="45.72" size="1.778" layer="96"/>
</instance>
<instance part="DB" gate="1" x="2.54" y="38.1" smashed="yes" rot="R270">
<attribute name="NAME" x="-1.27" y="35.56" size="1.778" layer="95"/>
<attribute name="VALUE" x="-1.27" y="33.02" size="1.778" layer="96"/>
</instance>
<instance part="SUPPLY1" gate="G$1" x="12.7" y="96.52" smashed="yes">
<attribute name="VALUE" x="10.795" y="99.695" size="1.778" layer="96"/>
</instance>
<instance part="SUPPLY2" gate="G$1" x="17.78" y="96.52" smashed="yes">
<attribute name="VALUE" x="15.875" y="99.695" size="1.778" layer="96"/>
</instance>
<instance part="SUPPLY3" gate="G$1" x="22.86" y="96.52" smashed="yes">
<attribute name="VALUE" x="20.955" y="99.695" size="1.778" layer="96"/>
</instance>
<instance part="SUPPLY4" gate="G$1" x="27.94" y="96.52" smashed="yes">
<attribute name="VALUE" x="26.035" y="99.695" size="1.778" layer="96"/>
</instance>
<instance part="SUPPLY5" gate="G$1" x="40.64" y="96.52" smashed="yes">
<attribute name="VALUE" x="38.735" y="99.695" size="1.778" layer="96"/>
</instance>
<instance part="SUPPLY6" gate="G$1" x="76.2" y="96.52" smashed="yes">
<attribute name="VALUE" x="74.295" y="99.695" size="1.778" layer="96"/>
</instance>
<instance part="SUPPLY7" gate="G$1" x="78.74" y="96.52" smashed="yes">
<attribute name="VALUE" x="76.835" y="99.695" size="1.778" layer="96"/>
</instance>
<instance part="SUPPLY8" gate="G$1" x="81.28" y="96.52" smashed="yes">
<attribute name="VALUE" x="79.375" y="99.695" size="1.778" layer="96"/>
</instance>
<instance part="SUPPLY9" gate="G$1" x="83.82" y="96.52" smashed="yes">
<attribute name="VALUE" x="81.915" y="99.695" size="1.778" layer="96"/>
</instance>
<instance part="SUPPLY10" gate="G$1" x="93.98" y="96.52" smashed="yes">
<attribute name="VALUE" x="92.075" y="99.695" size="1.778" layer="96"/>
</instance>
<instance part="SUPPLY11" gate="G$1" x="127" y="96.52" smashed="yes">
<attribute name="VALUE" x="125.095" y="99.695" size="1.778" layer="96"/>
</instance>
<instance part="SUPPLY12" gate="G$1" x="129.54" y="96.52" smashed="yes">
<attribute name="VALUE" x="127.635" y="99.695" size="1.778" layer="96"/>
</instance>
<instance part="SUPPLY13" gate="G$1" x="132.08" y="96.52" smashed="yes">
<attribute name="VALUE" x="130.175" y="99.695" size="1.778" layer="96"/>
</instance>
<instance part="SUPPLY14" gate="G$1" x="134.62" y="96.52" smashed="yes">
<attribute name="VALUE" x="132.715" y="99.695" size="1.778" layer="96"/>
</instance>
<instance part="SUPPLY15" gate="G$1" x="180.34" y="96.52" smashed="yes">
<attribute name="VALUE" x="178.435" y="99.695" size="1.778" layer="96"/>
</instance>
<instance part="SUPPLY16" gate="G$1" x="185.42" y="96.52" smashed="yes">
<attribute name="VALUE" x="183.515" y="99.695" size="1.778" layer="96"/>
</instance>
<instance part="SUPPLY17" gate="G$1" x="190.5" y="96.52" smashed="yes">
<attribute name="VALUE" x="188.595" y="99.695" size="1.778" layer="96"/>
</instance>
<instance part="SUPPLY18" gate="G$1" x="195.58" y="96.52" smashed="yes">
<attribute name="VALUE" x="193.675" y="99.695" size="1.778" layer="96"/>
</instance>
<instance part="SUPPLY19" gate="G$1" x="147.32" y="96.52" smashed="yes">
<attribute name="VALUE" x="145.415" y="99.695" size="1.778" layer="96"/>
</instance>
<instance part="IO6" gate="/1" x="88.9" y="33.02" smashed="yes">
<attribute name="NAME" x="83.82" y="38.735" size="2.032" layer="95"/>
<attribute name="VALUE" x="83.82" y="24.765" size="2.032" layer="96"/>
</instance>
<instance part="IO6" gate="/2" x="111.76" y="30.48" smashed="yes">
<attribute name="NAME" x="106.68" y="36.195" size="2.032" layer="95"/>
<attribute name="VALUE" x="106.68" y="22.225" size="2.032" layer="96"/>
</instance>
</instances>
<busses>
</busses>
<nets>
<net name="N$9" class="0">
<segment>
<pinref part="IO1" gate="A" pin="QE"/>
<wire x1="71.12" y1="71.12" x2="88.9" y2="71.12" width="0.1524" layer="91"/>
<wire x1="88.9" y1="71.12" x2="88.9" y2="81.28" width="0.1524" layer="91"/>
<pinref part="IO2" gate="A" pin="SER"/>
<wire x1="88.9" y1="81.28" x2="88.9" y2="83.82" width="0.1524" layer="91"/>
<wire x1="88.9" y1="83.82" x2="99.06" y2="83.82" width="0.1524" layer="91"/>
<pinref part="IO2" gate="A" pin="A"/>
<wire x1="99.06" y1="81.28" x2="88.9" y2="81.28" width="0.1524" layer="91"/>
<junction x="88.9" y="81.28"/>
</segment>
</net>
<net name="N$10" class="0">
<segment>
<wire x1="40.64" y1="53.34" x2="40.64" y2="60.96" width="0.1524" layer="91"/>
<pinref part="IO1" gate="A" pin="CLR"/>
<wire x1="40.64" y1="60.96" x2="45.72" y2="60.96" width="0.1524" layer="91"/>
<wire x1="40.64" y1="53.34" x2="93.98" y2="53.34" width="0.1524" layer="91"/>
<wire x1="93.98" y1="53.34" x2="93.98" y2="60.96" width="0.1524" layer="91"/>
<pinref part="IO2" gate="A" pin="CLR"/>
<wire x1="93.98" y1="60.96" x2="99.06" y2="60.96" width="0.1524" layer="91"/>
</segment>
</net>
<net name="N$11" class="0">
<segment>
<wire x1="35.56" y1="48.26" x2="35.56" y2="66.04" width="0.1524" layer="91"/>
<pinref part="IO1" gate="A" pin="CLK"/>
<wire x1="35.56" y1="66.04" x2="45.72" y2="66.04" width="0.1524" layer="91"/>
<wire x1="35.56" y1="48.26" x2="88.9" y2="48.26" width="0.1524" layer="91"/>
<wire x1="88.9" y1="48.26" x2="88.9" y2="66.04" width="0.1524" layer="91"/>
<pinref part="IO2" gate="A" pin="CLK"/>
<wire x1="88.9" y1="66.04" x2="99.06" y2="66.04" width="0.1524" layer="91"/>
<wire x1="35.56" y1="48.26" x2="35.56" y2="38.1" width="0.1524" layer="91"/>
<pinref part="IO5" gate="A" pin="CKA"/>
<wire x1="35.56" y1="38.1" x2="45.72" y2="38.1" width="0.1524" layer="91"/>
<junction x="35.56" y="48.26"/>
<pinref part="DB" gate="1" pin="2"/>
<wire x1="7.62" y1="38.1" x2="35.56" y2="38.1" width="0.1524" layer="91"/>
<junction x="35.56" y="38.1"/>
</segment>
</net>
<net name="N$12" class="0">
<segment>
<pinref part="IO5" gate="A" pin="QA"/>
<wire x1="71.12" y1="38.1" x2="73.66" y2="38.1" width="0.1524" layer="91"/>
<wire x1="73.66" y1="38.1" x2="73.66" y2="45.72" width="0.1524" layer="91"/>
<wire x1="73.66" y1="45.72" x2="43.18" y2="45.72" width="0.1524" layer="91"/>
<wire x1="43.18" y1="45.72" x2="43.18" y2="35.56" width="0.1524" layer="91"/>
<pinref part="IO5" gate="A" pin="CKB"/>
<wire x1="43.18" y1="35.56" x2="45.72" y2="35.56" width="0.1524" layer="91"/>
<wire x1="73.66" y1="38.1" x2="73.66" y2="35.56" width="0.1524" layer="91"/>
<pinref part="IO6" gate="/1" pin="A"/>
<wire x1="73.66" y1="35.56" x2="78.74" y2="35.56" width="0.1524" layer="91"/>
<junction x="73.66" y="38.1"/>
</segment>
</net>
<net name="N$18" class="0">
<segment>
<pinref part="IO6" gate="/2" pin="Y"/>
<wire x1="124.46" y1="30.48" x2="121.92" y2="30.48" width="0.1524" layer="91"/>
<pinref part="IO5" gate="A" pin="R0(1)"/>
<pinref part="IO5" gate="A" pin="R0(2)"/>
<wire x1="124.46" y1="30.48" x2="124.46" y2="50.8" width="0.1524" layer="91"/>
<wire x1="124.46" y1="50.8" x2="38.1" y2="50.8" width="0.1524" layer="91"/>
<wire x1="38.1" y1="50.8" x2="38.1" y2="63.5" width="0.1524" layer="91"/>
<pinref part="IO1" gate="A" pin="PE"/>
<wire x1="38.1" y1="63.5" x2="45.72" y2="63.5" width="0.1524" layer="91"/>
<junction x="124.46" y="30.48"/>
<pinref part="IO3" gate="A" pin="CLK"/>
<wire x1="152.4" y1="76.2" x2="149.86" y2="76.2" width="0.1524" layer="91"/>
<wire x1="149.86" y1="76.2" x2="149.86" y2="53.34" width="0.1524" layer="91"/>
<pinref part="IO3" gate="B" pin="CLK"/>
<wire x1="152.4" y1="53.34" x2="149.86" y2="53.34" width="0.1524" layer="91"/>
<junction x="149.86" y="53.34"/>
<wire x1="149.86" y1="53.34" x2="149.86" y2="30.48" width="0.1524" layer="91"/>
<pinref part="IO4" gate="A" pin="CLK"/>
<wire x1="152.4" y1="30.48" x2="149.86" y2="30.48" width="0.1524" layer="91"/>
<junction x="149.86" y="30.48"/>
<wire x1="149.86" y1="30.48" x2="149.86" y2="7.62" width="0.1524" layer="91"/>
<pinref part="IO4" gate="B" pin="CLK"/>
<wire x1="152.4" y1="7.62" x2="149.86" y2="7.62" width="0.1524" layer="91"/>
<pinref part="S5" gate="1" pin="2"/>
<wire x1="7.62" y1="50.8" x2="38.1" y2="50.8" width="0.1524" layer="91"/>
<junction x="38.1" y="50.8"/>
<wire x1="38.1" y1="50.8" x2="38.1" y2="30.48" width="0.1524" layer="91"/>
<wire x1="38.1" y1="30.48" x2="45.72" y2="30.48" width="0.1524" layer="91"/>
<wire x1="38.1" y1="30.48" x2="38.1" y2="27.94" width="0.1524" layer="91"/>
<wire x1="38.1" y1="27.94" x2="45.72" y2="27.94" width="0.1524" layer="91"/>
<junction x="38.1" y="30.48"/>
<wire x1="124.46" y1="30.48" x2="149.86" y2="30.48" width="0.1524" layer="91"/>
</segment>
</net>
<net name="VCC" class="0">
<segment>
<pinref part="IO1" gate="A" pin="E"/>
<wire x1="45.72" y1="71.12" x2="40.64" y2="71.12" width="0.1524" layer="91"/>
<wire x1="40.64" y1="71.12" x2="40.64" y2="83.82" width="0.1524" layer="91"/>
<pinref part="IO1" gate="A" pin="SER"/>
<wire x1="40.64" y1="83.82" x2="40.64" y2="93.98" width="0.1524" layer="91"/>
<wire x1="45.72" y1="83.82" x2="40.64" y2="83.82" width="0.1524" layer="91"/>
<junction x="40.64" y="83.82"/>
<pinref part="SUPPLY5" gate="G$1" pin="VCC"/>
</segment>
<segment>
<pinref part="IO1" gate="A" pin="QA"/>
<wire x1="71.12" y1="81.28" x2="76.2" y2="81.28" width="0.1524" layer="91"/>
<wire x1="76.2" y1="81.28" x2="76.2" y2="93.98" width="0.1524" layer="91"/>
<pinref part="SUPPLY6" gate="G$1" pin="VCC"/>
</segment>
<segment>
<pinref part="IO1" gate="A" pin="QB"/>
<wire x1="71.12" y1="78.74" x2="78.74" y2="78.74" width="0.1524" layer="91"/>
<wire x1="78.74" y1="78.74" x2="78.74" y2="93.98" width="0.1524" layer="91"/>
<pinref part="SUPPLY7" gate="G$1" pin="VCC"/>
</segment>
<segment>
<pinref part="IO1" gate="A" pin="QC"/>
<wire x1="71.12" y1="76.2" x2="81.28" y2="76.2" width="0.1524" layer="91"/>
<wire x1="81.28" y1="76.2" x2="81.28" y2="93.98" width="0.1524" layer="91"/>
<pinref part="SUPPLY8" gate="G$1" pin="VCC"/>
</segment>
<segment>
<pinref part="IO1" gate="A" pin="QD"/>
<wire x1="71.12" y1="73.66" x2="83.82" y2="73.66" width="0.1524" layer="91"/>
<wire x1="83.82" y1="73.66" x2="83.82" y2="93.98" width="0.1524" layer="91"/>
<pinref part="SUPPLY9" gate="G$1" pin="VCC"/>
</segment>
<segment>
<pinref part="IO2" gate="A" pin="B"/>
<wire x1="99.06" y1="78.74" x2="93.98" y2="78.74" width="0.1524" layer="91"/>
<wire x1="93.98" y1="78.74" x2="93.98" y2="93.98" width="0.1524" layer="91"/>
<pinref part="IO2" gate="A" pin="C"/>
<wire x1="99.06" y1="76.2" x2="93.98" y2="76.2" width="0.1524" layer="91"/>
<wire x1="93.98" y1="76.2" x2="93.98" y2="78.74" width="0.1524" layer="91"/>
<pinref part="IO2" gate="A" pin="D"/>
<wire x1="99.06" y1="73.66" x2="93.98" y2="73.66" width="0.1524" layer="91"/>
<wire x1="93.98" y1="73.66" x2="93.98" y2="76.2" width="0.1524" layer="91"/>
<pinref part="IO2" gate="A" pin="E"/>
<wire x1="99.06" y1="71.12" x2="93.98" y2="71.12" width="0.1524" layer="91"/>
<wire x1="93.98" y1="71.12" x2="93.98" y2="73.66" width="0.1524" layer="91"/>
<junction x="93.98" y="73.66"/>
<junction x="93.98" y="76.2"/>
<junction x="93.98" y="78.74"/>
<pinref part="SUPPLY10" gate="G$1" pin="VCC"/>
<pinref part="IO2" gate="A" pin="PE"/>
<wire x1="99.06" y1="63.5" x2="93.98" y2="63.5" width="0.1524" layer="91"/>
<wire x1="93.98" y1="63.5" x2="93.98" y2="71.12" width="0.1524" layer="91"/>
<junction x="93.98" y="71.12"/>
</segment>
<segment>
<pinref part="IO2" gate="A" pin="QA"/>
<pinref part="IO3" gate="A" pin="D"/>
<wire x1="124.46" y1="81.28" x2="127" y2="81.28" width="0.1524" layer="91"/>
<wire x1="127" y1="81.28" x2="152.4" y2="81.28" width="0.1524" layer="91"/>
<wire x1="127" y1="81.28" x2="127" y2="93.98" width="0.1524" layer="91"/>
<junction x="127" y="81.28"/>
<pinref part="SUPPLY11" gate="G$1" pin="VCC"/>
</segment>
<segment>
<pinref part="IO2" gate="A" pin="QB"/>
<wire x1="124.46" y1="78.74" x2="129.54" y2="78.74" width="0.1524" layer="91"/>
<wire x1="129.54" y1="78.74" x2="129.54" y2="93.98" width="0.1524" layer="91"/>
<wire x1="129.54" y1="78.74" x2="129.54" y2="58.42" width="0.1524" layer="91"/>
<pinref part="IO3" gate="B" pin="D"/>
<wire x1="129.54" y1="58.42" x2="152.4" y2="58.42" width="0.1524" layer="91"/>
<junction x="129.54" y="78.74"/>
<pinref part="SUPPLY12" gate="G$1" pin="VCC"/>
</segment>
<segment>
<pinref part="IO2" gate="A" pin="QC"/>
<wire x1="124.46" y1="76.2" x2="132.08" y2="76.2" width="0.1524" layer="91"/>
<wire x1="132.08" y1="76.2" x2="132.08" y2="93.98" width="0.1524" layer="91"/>
<wire x1="132.08" y1="76.2" x2="132.08" y2="35.56" width="0.1524" layer="91"/>
<pinref part="IO4" gate="A" pin="D"/>
<wire x1="132.08" y1="35.56" x2="152.4" y2="35.56" width="0.1524" layer="91"/>
<junction x="132.08" y="76.2"/>
<pinref part="SUPPLY13" gate="G$1" pin="VCC"/>
</segment>
<segment>
<pinref part="IO2" gate="A" pin="QD"/>
<wire x1="124.46" y1="73.66" x2="134.62" y2="73.66" width="0.1524" layer="91"/>
<wire x1="134.62" y1="73.66" x2="134.62" y2="93.98" width="0.1524" layer="91"/>
<wire x1="134.62" y1="73.66" x2="134.62" y2="12.7" width="0.1524" layer="91"/>
<pinref part="IO4" gate="B" pin="D"/>
<wire x1="134.62" y1="12.7" x2="152.4" y2="12.7" width="0.1524" layer="91"/>
<junction x="134.62" y="73.66"/>
<pinref part="SUPPLY14" gate="G$1" pin="VCC"/>
</segment>
<segment>
<pinref part="IO3" gate="A" pin="Q"/>
<wire x1="177.8" y1="83.82" x2="180.34" y2="83.82" width="0.1524" layer="91"/>
<wire x1="180.34" y1="83.82" x2="180.34" y2="93.98" width="0.1524" layer="91"/>
<pinref part="SUPPLY15" gate="G$1" pin="VCC"/>
</segment>
<segment>
<pinref part="IO3" gate="B" pin="Q"/>
<wire x1="177.8" y1="60.96" x2="185.42" y2="60.96" width="0.1524" layer="91"/>
<wire x1="185.42" y1="60.96" x2="185.42" y2="93.98" width="0.1524" layer="91"/>
<pinref part="SUPPLY16" gate="G$1" pin="VCC"/>
</segment>
<segment>
<pinref part="IO4" gate="A" pin="Q"/>
<wire x1="177.8" y1="38.1" x2="190.5" y2="38.1" width="0.1524" layer="91"/>
<wire x1="190.5" y1="38.1" x2="190.5" y2="93.98" width="0.1524" layer="91"/>
<pinref part="SUPPLY17" gate="G$1" pin="VCC"/>
</segment>
<segment>
<pinref part="IO4" gate="B" pin="Q"/>
<wire x1="177.8" y1="15.24" x2="195.58" y2="15.24" width="0.1524" layer="91"/>
<wire x1="195.58" y1="15.24" x2="195.58" y2="93.98" width="0.1524" layer="91"/>
<pinref part="SUPPLY18" gate="G$1" pin="VCC"/>
</segment>
<segment>
<pinref part="S2" gate="1" pin="2"/>
<pinref part="SUPPLY2" gate="G$1" pin="VCC"/>
<wire x1="7.62" y1="73.66" x2="17.78" y2="73.66" width="0.1524" layer="91"/>
<wire x1="17.78" y1="73.66" x2="17.78" y2="78.74" width="0.1524" layer="91"/>
<pinref part="IO1" gate="A" pin="B"/>
<wire x1="17.78" y1="78.74" x2="17.78" y2="93.98" width="0.1524" layer="91"/>
<wire x1="45.72" y1="78.74" x2="17.78" y2="78.74" width="0.1524" layer="91"/>
<junction x="17.78" y="78.74"/>
</segment>
<segment>
<pinref part="S3" gate="1" pin="2"/>
<pinref part="SUPPLY3" gate="G$1" pin="VCC"/>
<wire x1="7.62" y1="66.04" x2="22.86" y2="66.04" width="0.1524" layer="91"/>
<wire x1="22.86" y1="66.04" x2="22.86" y2="76.2" width="0.1524" layer="91"/>
<pinref part="IO1" gate="A" pin="C"/>
<wire x1="22.86" y1="76.2" x2="22.86" y2="93.98" width="0.1524" layer="91"/>
<wire x1="45.72" y1="76.2" x2="22.86" y2="76.2" width="0.1524" layer="91"/>
<junction x="22.86" y="76.2"/>
</segment>
<segment>
<pinref part="S4" gate="1" pin="2"/>
<pinref part="SUPPLY4" gate="G$1" pin="VCC"/>
<wire x1="7.62" y1="58.42" x2="27.94" y2="58.42" width="0.1524" layer="91"/>
<wire x1="27.94" y1="58.42" x2="27.94" y2="73.66" width="0.1524" layer="91"/>
<pinref part="IO1" gate="A" pin="D"/>
<wire x1="27.94" y1="73.66" x2="27.94" y2="93.98" width="0.1524" layer="91"/>
<wire x1="45.72" y1="73.66" x2="27.94" y2="73.66" width="0.1524" layer="91"/>
<junction x="27.94" y="73.66"/>
</segment>
<segment>
<pinref part="IO1" gate="A" pin="A"/>
<pinref part="S1" gate="1" pin="2"/>
<wire x1="45.72" y1="81.28" x2="12.7" y2="81.28" width="0.1524" layer="91"/>
<pinref part="SUPPLY1" gate="G$1" pin="VCC"/>
<wire x1="12.7" y1="81.28" x2="7.62" y2="81.28" width="0.1524" layer="91"/>
<wire x1="12.7" y1="93.98" x2="12.7" y2="81.28" width="0.1524" layer="91"/>
<junction x="12.7" y="81.28"/>
</segment>
<segment>
<pinref part="IO3" gate="A" pin="PRE"/>
<wire x1="152.4" y1="83.82" x2="147.32" y2="83.82" width="0.1524" layer="91"/>
<wire x1="147.32" y1="83.82" x2="147.32" y2="73.66" width="0.1524" layer="91"/>
<pinref part="IO4" gate="B" pin="CLR"/>
<wire x1="147.32" y1="73.66" x2="147.32" y2="60.96" width="0.1524" layer="91"/>
<wire x1="147.32" y1="60.96" x2="147.32" y2="50.8" width="0.1524" layer="91"/>
<wire x1="147.32" y1="50.8" x2="147.32" y2="38.1" width="0.1524" layer="91"/>
<wire x1="147.32" y1="38.1" x2="147.32" y2="27.94" width="0.1524" layer="91"/>
<wire x1="147.32" y1="27.94" x2="147.32" y2="15.24" width="0.1524" layer="91"/>
<wire x1="147.32" y1="15.24" x2="147.32" y2="5.08" width="0.1524" layer="91"/>
<wire x1="152.4" y1="5.08" x2="147.32" y2="5.08" width="0.1524" layer="91"/>
<pinref part="IO4" gate="B" pin="PRE"/>
<wire x1="152.4" y1="15.24" x2="147.32" y2="15.24" width="0.1524" layer="91"/>
<pinref part="IO4" gate="A" pin="PRE"/>
<wire x1="152.4" y1="38.1" x2="147.32" y2="38.1" width="0.1524" layer="91"/>
<pinref part="IO4" gate="A" pin="CLR"/>
<wire x1="152.4" y1="27.94" x2="147.32" y2="27.94" width="0.1524" layer="91"/>
<pinref part="IO3" gate="B" pin="CLR"/>
<wire x1="152.4" y1="50.8" x2="147.32" y2="50.8" width="0.1524" layer="91"/>
<pinref part="IO3" gate="B" pin="PRE"/>
<wire x1="152.4" y1="60.96" x2="147.32" y2="60.96" width="0.1524" layer="91"/>
<pinref part="IO3" gate="A" pin="CLR"/>
<wire x1="152.4" y1="73.66" x2="147.32" y2="73.66" width="0.1524" layer="91"/>
<junction x="147.32" y="73.66"/>
<junction x="147.32" y="60.96"/>
<junction x="147.32" y="50.8"/>
<junction x="147.32" y="38.1"/>
<junction x="147.32" y="27.94"/>
<junction x="147.32" y="15.24"/>
<pinref part="SUPPLY19" gate="G$1" pin="VCC"/>
<wire x1="147.32" y1="93.98" x2="147.32" y2="83.82" width="0.1524" layer="91"/>
<junction x="147.32" y="83.82"/>
</segment>
</net>
<net name="N$2" class="0">
<segment>
<pinref part="IO5" gate="A" pin="QD"/>
<pinref part="IO6" gate="/1" pin="B"/>
<wire x1="71.12" y1="30.48" x2="78.74" y2="30.48" width="0.1524" layer="91"/>
</segment>
</net>
<net name="N$1" class="0">
<segment>
<pinref part="IO6" gate="/1" pin="Y"/>
<pinref part="IO6" gate="/2" pin="A"/>
<wire x1="99.06" y1="33.02" x2="101.6" y2="33.02" width="0.1524" layer="91"/>
<pinref part="IO6" gate="/2" pin="B"/>
<wire x1="101.6" y1="33.02" x2="101.6" y2="27.94" width="0.1524" layer="91"/>
<junction x="101.6" y="33.02"/>
</segment>
</net>
</nets>
</sheet>
</sheets>
</schematic>
</drawing>
</eagle>
