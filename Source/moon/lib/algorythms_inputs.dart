import 'package:flutter/material.dart';
import 'package:flutter/services.dart';

class SawingInputsPlain extends StatefulWidget {
  final Function(double, double, double, double) getInputsP;
  const SawingInputsPlain(this.getInputsP, {super.key});
  @override
  State<SawingInputsPlain> createState() => _SawingInputsPlainState();
}

class _SawingInputsPlainState extends State<SawingInputsPlain> {
  TextStyle styleTitle = TextStyle(fontSize: 30);
  double logSize = 0;
  bool repetition = false;
  double discoveryHeight = 0;
  double lumberHeight = 0;
  double lumberWidth = 0;
  @override
  Widget build(BuildContext context){
    return Column(
      children: [
        TextField(
          textAlign: TextAlign.center,
          decoration: const InputDecoration(
            border: OutlineInputBorder(),
            labelText: "Log Size",
          ),
          inputFormatters: <TextInputFormatter>[
            FilteringTextInputFormatter.digitsOnly
          ],
          onChanged: (text) {
            if(text == '')
            {
              logSize = 0;
              widget.getInputsP(logSize, discoveryHeight, lumberWidth, lumberHeight);
            }
            else
            {
              logSize = double.parse(text);
              widget.getInputsP(logSize, discoveryHeight, lumberWidth, lumberHeight);
            }
          },
        ),
        Text(
          "Wanted Lumber",
          style: styleTitle,
        ),
        TextField(
          textAlign: TextAlign.center,
          inputFormatters: <TextInputFormatter>[
            FilteringTextInputFormatter.digitsOnly
          ],
          onChanged: (value) {
          if(value !='')
            {
              lumberWidth = double.parse(value);
              widget.getInputsP(logSize, discoveryHeight, lumberWidth, lumberHeight);
            }                    
          },
        ),
        TextField(
          textAlign: TextAlign.center,
          inputFormatters: <TextInputFormatter>[
            FilteringTextInputFormatter.digitsOnly
          ],
          onChanged: (value) {
          if(value !='')
            {
              lumberHeight = double.parse(value);
              widget.getInputsP(logSize, discoveryHeight, lumberWidth, lumberHeight);
            }                    
          },
        ),
        Row(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Checkbox(
              value: repetition, 
              onChanged: (value) {
              setState(() {
                repetition = value!;
                widget.getInputsP(logSize, discoveryHeight, lumberWidth, lumberHeight);
              });
            }),
            Text(
              "Repetition"
            )
          ],
        ),
        TextField(
          textAlign: TextAlign.center,
          inputFormatters: <TextInputFormatter>[
            FilteringTextInputFormatter.digitsOnly
          ],
          onChanged: (value) {
          if(value !='')
            {
              discoveryHeight = double.parse(value);
              widget.getInputsP(logSize, discoveryHeight, lumberWidth, lumberHeight);
            }                    
          },
          decoration: const InputDecoration(
            labelText: "Discovery Plank",
            border: OutlineInputBorder(),
          ),
        ),
      ]
    );
  }      
}

class SawingInputsLive extends StatefulWidget {
  final Function(double, double) getInputs;
  const SawingInputsLive(this.getInputs, {super.key});
  @override
  State<SawingInputsLive> createState() => _SawingInputsLiveState();
}

class _SawingInputsLiveState extends State<SawingInputsLive> {
  TextStyle styleTitle = TextStyle(fontSize: 30);
  double logSize = 0;
  bool repetition = false;
  double discoveryHeight = 0;
  @override
  Widget build(BuildContext context){
    return Column(
      children: [
        TextField(
          textAlign: TextAlign.center,
          decoration: const InputDecoration(
            border: OutlineInputBorder(),
            labelText: "Log Size",
          ),
          inputFormatters: <TextInputFormatter>[
            FilteringTextInputFormatter.digitsOnly
          ],
          onChanged: (text) {
            if(text == '')
            {
              logSize = 0;
              widget.getInputs(logSize, discoveryHeight);
            }
            else
            {
              logSize = double.parse(text);
              widget.getInputs(logSize, discoveryHeight);
            }
          },
        ),
        Container(height: 50,),
        TextField(
          textAlign: TextAlign.center,
          decoration: const InputDecoration(
            border: OutlineInputBorder(),
            labelText: "Slab Thickness",
          ),
          inputFormatters: <TextInputFormatter>[
            FilteringTextInputFormatter.digitsOnly
          ],
          onChanged: (value) {
          if(value !='')
            {
              discoveryHeight = double.parse(value);
              widget.getInputs(logSize, discoveryHeight);
            }                    
          },
        ),
      ]
    );
  }      
}