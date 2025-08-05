import {ThemeToggle} from "@/components/ui/theme-toggle.tsx";
import {Input} from "@/components/ui/input.tsx";
import {Button} from "@/components/ui/button.tsx";
import {Label} from "@/components/ui/label.tsx";
import {GitHubLogo} from "@/components/logo/github-logo.tsx";
import {GoogleLogo} from "@/components/logo/google-logo.tsx";
import {MicrosoftLogo} from "@/components/logo/microsoft-logo.tsx";
export function LoginPage() {

    return (
        <div id="parent-login-div" className="h-screen p-3">
            <div id="header-right" className="flex justify-end">
                <ThemeToggle/>
            </div>
            <div id="login-centre-card" className="flex flex-col items-center mt-[25vh] bg-white/30 dark:bg-black/30 backdrop-blur-md rounded-xl p-8 shadow-lg max-w-md mx-auto">
                <div id="login-centre-card-title" className="flex flex-col items-center">
                    <h1>Welcome To Relos</h1>

                    <div id="login-centre-card-username-row" className="flex flex-col pt-10">
                        <Label htmlFor="username">Username</Label>
                        <div className="pt-1">
                            <div id="login-centre-card-username-field"></div>
                        <Input className="text-center w-80"/>
                        </div>

                        <div id="password-label-row" className="flex justify-between items-center w-80 mt-4">
                            <Label htmlFor="password">Password</Label>
                            <button className="text-xs text-gray-300 hover:underline">Forgot Password?</button>
                        </div>

                        <div id="login-centre-card-password-field" className="flex flex-col items-center pt-1">
                            <Input type="password" className="text-center w-80"/>

                            <div id="login-centre-card-register-section" className="flex justify-start w-full pt-2">
                                <button className="text-sm">Register</button>
                            </div>

                            <div id="login-centre-card-submit" className="pt-2">
                                <Button>Login</Button>
                            </div>
                            <div id="login-centre-card-sso" className=" pt-3 flex flex-row gap-5">
                            <GitHubLogo size={32}/>
                            <GoogleLogo size={32}/>
                                <MicrosoftLogo size={32}/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}