import 'package:ea_frontend/widgets/responsive_widget.dart';
import 'package:flutter/material.dart';
import 'package:url_launcher/url_launcher_string.dart';
import 'package:url_launcher/url_launcher.dart';

const googlePlayURL =
    'https://play.google.com/store/apps/details?id=com.google.android.youtube';
const appStoreURL = 'https://apps.apple.com/tw/app/youtube/id544007664';

class HomeContent extends ResponsiveWidget {
  const HomeContent({Key? key}) : super(key: key);

  @override
  Widget buildDesktop(BuildContext context) => const DesktopHomeContent();

  @override
  Widget buildMobile(BuildContext context) => const MobileHomeContent();
}

class DesktopHomeContent extends StatelessWidget {
  const DesktopHomeContent({super.key});

  @override
  Widget build(BuildContext context) {
    double height = MediaQuery.of(context).size.height;
    double width = MediaQuery.of(context).size.width;

    return SizedBox(
      height: height * 0.87,
      child: Row(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          SizedBox(
            height: height * 0.87,
            child: Row(
              children: [
                SizedBox(
                  width: width * 0.3,
                  child: Center(
                    child: Image.asset(
                      'images/demo.png',
                      height: 550,
                    ),
                  ),
                ),
                SizedBox(width: width * 0.13),
                Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    Padding(
                      padding: const EdgeInsets.only(left: 10),
                      child: Image.asset(
                        'images/download.png',
                        height: 155,
                      ),
                    ),
                    SizedBox(height: height * 0.08),
                    Row(
                      children: [
                        Padding(
                          padding: const EdgeInsets.fromLTRB(0, 50, 0, 0),
                          child: Image.asset(
                            'images/app.png',
                            height: 200,
                          ),
                        ),
                        SizedBox(width: width * 0.055),
                        Column(
                          children: [
                            GestureDetector(
                              onTap: () {
                                // ignore: deprecated_member_use
                                launch(
                                    'https://twitter.com/Grup4Ea'); // Reemplaza con tu enlace deseado
                              },
                              child:
                                  Image.asset('images/android.png', height: 60),
                            ),
                            SizedBox(height: height * 0.02),
                            GestureDetector(
                              onTap: () {
                                // ignore: deprecated_member_use
                                launch(
                                    'https://twitter.com/Grup4Ea'); // Reemplaza con tu enlace deseado
                              },
                              child: Image.asset('images/ios.png', height: 64),
                            ),
                          ],
                        ),
                      ],
                    ),
                  ],
                ),
              ],
            ),
          )
        ],
      ),
    );
  }
}

class MobileHomeContent extends StatelessWidget {
  const MobileHomeContent({super.key});

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.fromLTRB(24, 24, 24, 0),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.center,
        children: [
          const SizedBox(height: 48),
          Image.asset(
            'images/demo.png',
            height: 450,
          ),
          const SizedBox(height: 48),
          GestureDetector(
            onTap: () => launchUrlString(googlePlayURL),
            child: Image.asset(
              'images/android.png',
              height: 60,
              width: 200,
            ),
          ),
          const SizedBox(height: 48),
          GestureDetector(
            onTap: () => launchUrlString(appStoreURL),
            child: Image.asset(
              'images/ios.png',
              height: 64,
              width: 200,
            ),
          ),
          const SizedBox(height: 48),
        ],
      ),
    );
  }
}
