import 'package:flutter/material.dart';
import 'package:flutter/services.dart';

class SawingInputs extends StatefulWidget {
  @override
  State<SawingInputs> createState() => _SawingInputsState();
}

class _SawingInputsState extends State<SawingInputs> {
  TextStyle styleTitle = TextStyle(fontSize: 30);
  double logSize = 0;
  bool repetition = false;
  double discoveryHeight = 0;
  @override
  Widget build(BuildContext context){
    return Column(
      children: [
        Text(
          "Log Size", 
          style: styleTitle,
        ),
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
            }
            else
            {
              logSize = double.parse(text);
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
              });
            }),
            Text(
              "Repetition"
            )
          ],
        ),
        Text(
          "Discovery Plank",
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
              discoveryHeight = double.parse(value);
            }                    
          },
        ),
      ]
    );
  }            
}