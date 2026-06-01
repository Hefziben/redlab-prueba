import { redirect } from "next/navigation";

export default function RootPage() {
  // Redirecciona automáticamente al login en el primer milisegundo
  redirect("/dashboard");
}