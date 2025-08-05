import './App.css'
import {LoginPage} from "@/routes/_login.tsx";
import {ThemeProvider} from "@/components/ui/theme-provider.tsx";

function App() {
    return (
        <ThemeProvider>
        <LoginPage/>
        </ThemeProvider>
    )
}

export default App
