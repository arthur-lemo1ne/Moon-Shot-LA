import 'package:flutter/material.dart';
import 'package:moon/optimize_sawing.dart';

void main() {
  runApp(const MainApp());
}


class MainApp extends StatelessWidget {
  const MainApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'SawMill++',
      theme: ThemeData(
        useMaterial3: true,
        colorScheme: ColorScheme.fromSeed(seedColor: Colors.blue),
      ),
      home: HomePage(),
    );
  }
}


class HomePage extends StatefulWidget{
  const HomePage({super.key});

  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  var selectedIndex = 0;
  var extended = false;
  bool drawcuts = false;

  @override
  Widget build(BuildContext context){
    Widget page;
    switch (selectedIndex){
      case 0:
        page = Placeholder();
        break;
      case 1:
        page = OptimizeSawing();
        break;
      case 2:
        page = Placeholder();
        break;
      case 3:
        page = Placeholder();
        break;
      case 4:
        page = Placeholder();
        break;
      default:
        throw UnimplementedError('no widget for $selectedIndex');
    }

    return LayoutBuilder(
      builder: (BuildContext context, BoxConstraints constraints){
        return Scaffold(
          body: Row(
            children: [
              SafeArea(
                child: MouseRegion(
                  onEnter: (event) => setState(() {
                    extended = true;
                  }),
                  onExit: (event) => setState(() {
                    extended = false;
                  }),
                  child: NavigationRail(
                    minExtendedWidth: 200,
                    minWidth: 75,
                    extended: extended,
                    selectedIndex: selectedIndex,
                    backgroundColor: Colors.white,//Theme.of(context).colorScheme.secondaryContainer,
                    indicatorColor: Theme.of(context).colorScheme.primary,
                    selectedIconTheme: IconThemeData(color: Colors.white),
                    destinations: [
                      NavigationRailDestination(
                        icon: Icon(Icons.home),
                        label: Text('Home'),
                      ),
                      NavigationRailDestination(
                        icon: Icon(Icons.carpenter),
                        label: Text('Sawing'),
                      ),
                      NavigationRailDestination(
                        icon: Icon(Icons.groups),
                        label: Text('Client\'s Orders'),
                      ),
                      NavigationRailDestination(
                        icon: Icon(Icons.inventory),
                        label: Text('Stock'),
                      ),
                      NavigationRailDestination(
                        icon: Icon(Icons.settings),
                        label: Text('Setting'),
                      ),
                    ],
                    onDestinationSelected: (value) {
                      setState(() {
                        selectedIndex = value;
                      });
                    },
                  ),
                ),
              ),
              Expanded(
                child: Container(
                  color: Theme.of(context).colorScheme.primaryContainer,
                  child: page,
                ),
              )
            ]
          ),
        );
      }
    );
  }
}
