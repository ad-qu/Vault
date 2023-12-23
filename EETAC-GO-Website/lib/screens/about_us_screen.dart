import 'package:flutter/material.dart';
import 'package:ea_frontend/widgets/responsive_widget.dart';

class OurAppContent extends ResponsiveWidget {
  const OurAppContent({Key? key}) : super(key: key);

  @override
  Widget buildDesktop(BuildContext context) => const DesktopOurAppContent(200);

  @override
  Widget buildMobile(BuildContext context) => const MobileOurAppContent(24);
}

class DesktopOurAppContent extends StatelessWidget {
  // ignore: prefer_typing_uninitialized_variables
  final horizontalPadding;

  const DesktopOurAppContent(this.horizontalPadding, {super.key});

  @override
  Widget build(BuildContext context) {
    double height = MediaQuery.of(context).size.height;
    double width = MediaQuery.of(context).size.width;
    return SizedBox(
      height: height * 0.87,
      child: Column(
        children: [
          SizedBox(height: height * 0.08),
          Image.asset(
            'images/know_2.png',
            height: 63,
          ),
          SizedBox(height: height * 0.08),
          Row(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              SizedBox(
                width: width * 0.45,
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  crossAxisAlignment: CrossAxisAlignment.center,
                  children: [
                    Container(
                      decoration: BoxDecoration(
                          color: const Color.fromRGBO(255, 255, 255, 0.4),
                          borderRadius: BorderRadius.circular(15)),
                      child: const Padding(
                        padding: EdgeInsets.all(15.0),
                        child: Text(
                          "Hello everybody! We are Maria, Mario, Marcel, Pau and Adrián, a team of students who have created the EETAC Go app. Our passion for mobile app development has led us to collaborate in this project and we have put all our effort to design and build an innovative app. We are excited to present you EETAC Go and we hope you enjoy all the functionalities we have developed.",
                          style: TextStyle(fontWeight: FontWeight.w500),
                          textAlign: TextAlign.justify,
                        ),
                      ),
                    ),
                    SizedBox(height: height * 0.025),
                    Image.asset(
                      'images/photo_name.png',
                      height: 400,
                    ),
                  ],
                ),
              ),
            ],
          )
        ],
      ),
    );
  }
}

class MobileOurAppContent extends StatelessWidget {
  // ignore: prefer_typing_uninitialized_variables
  final horizontalPadding;

  const MobileOurAppContent(this.horizontalPadding, {super.key});

  @override
  Widget build(BuildContext context) {
    double height = MediaQuery.of(context).size.height;
    double width = MediaQuery.of(context).size.width;
    return SizedBox(
      height: height * 0.8,
      child: Column(
        children: [
          SizedBox(height: height * 0.08),
          Image.asset(
            'images/know_2.png',
            height: 63,
          ),
          SizedBox(height: height * 0.08),
          Row(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              SizedBox(
                width: width * 0.7,
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  crossAxisAlignment: CrossAxisAlignment.center,
                  children: [
                    Container(
                      decoration: BoxDecoration(
                          color: const Color.fromRGBO(255, 255, 255, 0.4),
                          borderRadius: BorderRadius.circular(15)),
                      child: const Padding(
                        padding: EdgeInsets.all(15.0),
                        child: Text(
                          "Hello everybody! We are Maria, Mario, Marcel, Pau and Adrián, a team of students who have created the EETAC Go app. Our passion for mobile app development has led us to collaborate in this project and we have put all our effort to design and build an innovative app. We are excited to present you EETAC Go and we hope you enjoy all the functionalities we have developed.",
                          style: TextStyle(fontWeight: FontWeight.w500),
                          textAlign: TextAlign.justify,
                        ),
                      ),
                    ),
                    Image.asset(
                      'images/photo_name.png',
                      height: 400,
                    ),
                  ],
                ),
              ),
            ],
          )
        ],
      ),
    );
  }
}
