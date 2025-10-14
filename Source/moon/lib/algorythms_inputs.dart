import 'package:flutter/material.dart';
import 'package:flutter/services.dart';

class SawingInputsPlain extends StatefulWidget {
  final Function(double, double) getInputs;
  const SawingInputsPlain(this.getInputs, {super.key});
  @override
  State<SawingInputsPlain> createState() => _SawingInputsPlainState();
}

class _SawingInputsPlainState extends State<SawingInputsPlain> {
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
        Text(
          "Wanted Lumber",
          style: styleTitle,
        ),
        TextField(
          textAlign: TextAlign.center,
        ),
        TextField(
          textAlign: TextAlign.center,
        ),
        Row(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Checkbox(
              value: repetition, 
              onChanged: (value) {
              setState(() {
                repetition = value!;
                widget.getInputs(logSize, discoveryHeight);
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
              widget.getInputs(logSize, discoveryHeight);
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