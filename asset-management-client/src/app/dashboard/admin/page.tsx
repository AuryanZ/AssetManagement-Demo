"use client"
import { getAssets } from "@/api/assets/getAssets";
import { useEffect } from "react";

export default function userDashboard() {

  useEffect(() => {
    getAssets();
  }, [])
  return (
    <div>
      <h1>adminDashboard</h1>

    </div>
  );
}