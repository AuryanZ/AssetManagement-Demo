import type { Metadata } from "next";
import { Inter } from "next/font/google";
import "./globals.css";
import Footer from "@/components/Footer/footer";
import Header from "@/components/Header/header";
import { AuthProvider } from "@/events/eventContext";

const inter = Inter({ subsets: ["latin"] });

export const metadata: Metadata = {
  title: "Asset Management Client",
  description: "Generated by create next app",
};

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <html lang="en">

      <body className={inter.className} >
        <AuthProvider>
          <div>
            <Header />
            <div>{children}</div>
            <Footer />
          </div>
        </AuthProvider>
      </body>

    </html>
  );
}
