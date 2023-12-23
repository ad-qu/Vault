import 'package:ea_frontend/navbar/nav_bar_button.dart';
import 'package:ea_frontend/widgets/responsive_widget.dart';
import 'package:ea_frontend/website.dart';
import 'package:flutter/material.dart';
// ignore: depend_on_referenced_packages
import 'package:flutter_hooks/flutter_hooks.dart';
import 'package:hooks_riverpod/hooks_riverpod.dart';

class NavBar extends ResponsiveWidget {
  const NavBar({Key? key}) : super(key: key);

  @override
  Widget buildDesktop(BuildContext context) {
    return const DesktopNavBar();
  }

  @override
  Widget buildMobile(BuildContext context) {
    return const MobileNavBar();
  }
}

class DesktopNavBar extends HookConsumerWidget {
  const DesktopNavBar({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    return Container(
      decoration: BoxDecoration(
        color: const Color.fromARGB(255, 240, 240, 240),
        boxShadow: [
          BoxShadow(
            color: Colors.black.withOpacity(0.2),
            offset: const Offset(0, -4),
            blurRadius: 15,
          ),
        ],
      ),
      child: Padding(
        padding: const EdgeInsets.fromLTRB(25, 30, 50, 30),
        child: Row(
          children: <Widget>[
            Image.asset(
              "images/eetac_go.png",
              height: 70.0,
            ),
            Expanded(child: Container()),
            NavBarButton(
              onTap: () =>
                  ref.read(currentPageProvider.notifier).state = homeKey,
              text: "HOME",
            ),
            NavBarButton(
              onTap: () =>
                  ref.read(currentPageProvider.notifier).state = ourAppKey,
              text: "OUR APP",
            ),
            NavBarButton(
              onTap: () =>
                  ref.read(currentPageProvider.notifier).state = aboutUsKey,
              text: "ABOUT US",
            ),
            NavBarButton(
              onTap: () =>
                  ref.read(currentPageProvider.notifier).state = contactKey,
              text: "CONTACT",
            ),
          ],
        ),
      ),
    );
  }
}

class MobileNavBar extends HookConsumerWidget {
  const MobileNavBar({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    final containerHeight = useState<double>(0.0);
    bool menuClicked = false;

    return Stack(
      children: [
        Container(
          decoration: BoxDecoration(
            boxShadow: [
              BoxShadow(
                color: Colors.black.withOpacity(0.2),
                offset: const Offset(0, -4),
                blurRadius: 15,
              ),
            ],
          ),
          child: AnimatedContainer(
            color: const Color.fromARGB(255, 240, 240, 240),
            margin: const EdgeInsets.only(top: 127.5),
            duration: const Duration(milliseconds: 350),
            curve: Curves.ease,
            height: containerHeight.value,
            child: SingleChildScrollView(
              child: Column(
                children: [
                  NavBarButton(
                    text: "HOME",
                    onTap: () {
                      ref.read(currentPageProvider.notifier).state = homeKey;
                      containerHeight.value = 0;
                    },
                  ),
                  NavBarButton(
                    text: "OUR APP",
                    onTap: () {
                      ref.read(currentPageProvider.notifier).state = ourAppKey;
                      containerHeight.value = 0;
                    },
                  ),
                  NavBarButton(
                    text: "ABOUT US",
                    onTap: () {
                      ref.read(currentPageProvider.notifier).state = aboutUsKey;
                      containerHeight.value = 0;
                    },
                  ),
                  NavBarButton(
                    text: "CONTACT",
                    onTap: () {
                      ref.read(currentPageProvider.notifier).state = contactKey;
                      containerHeight.value = 0;
                    },
                  ),
                ],
              ),
            ),
          ),
        ),
        if (menuClicked == true)
          Container(
            decoration: BoxDecoration(
              color: const Color.fromARGB(255, 240, 240, 240),
              boxShadow: [
                BoxShadow(
                  color: Colors.black.withOpacity(0.2),
                  offset: const Offset(0, -4),
                  blurRadius: 15,
                ),
              ],
            ),
            child: Padding(
              padding: const EdgeInsets.fromLTRB(25, 30, 65, 30),
              child: Row(
                children: <Widget>[
                  Image.asset(
                    "images/eetac_go.png",
                    height: 70.0,
                  ),
                  Expanded(
                    child: Container(),
                  ),
                  Material(
                    child: InkWell(
                      splashColor: const Color.fromARGB(153, 255, 255, 255),
                      onTap: () {
                        final height = containerHeight.value > 0 ? 0.0 : 240.0;
                        containerHeight.value = height;
                        menuClicked = true;
                      },
                      child: Container(
                        color: const Color.fromARGB(255, 240, 240,
                            240), // Establece el color de fondo del botón a blanco
                        child: const Icon(
                          Icons.menu,
                          color: Color.fromARGB(255, 25, 25, 25),
                          size: 30,
                        ),
                      ),
                    ),
                  ),
                ],
              ),
            ),
          )
        else
          Container(
            decoration: const BoxDecoration(
              color: Color.fromARGB(255, 240, 240, 240),
            ),
            child: Padding(
              padding: const EdgeInsets.fromLTRB(25, 30, 65, 30),
              child: Row(
                children: <Widget>[
                  Image.asset(
                    "images/eetac_go.png",
                    height: 70.0,
                  ),
                  Expanded(
                    child: Container(),
                  ),
                  Material(
                    child: InkWell(
                      splashColor: const Color.fromARGB(153, 255, 255, 255),
                      onTap: () {
                        final height = containerHeight.value > 0 ? 0.0 : 240.0;
                        containerHeight.value = height;
                        menuClicked = true;
                      },
                      child: Container(
                        color: const Color.fromARGB(255, 240, 240,
                            240), // Establece el color de fondo del botón a blanco
                        child: const Icon(
                          Icons.menu,
                          color: Color.fromARGB(255, 25, 25, 25),
                          size: 30,
                        ),
                      ),
                    ),
                  ),
                ],
              ),
            ),
          )
      ],
    );
  }
}
